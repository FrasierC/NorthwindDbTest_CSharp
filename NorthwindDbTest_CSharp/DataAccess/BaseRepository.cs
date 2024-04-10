using Newtonsoft.Json;
using NorthwindDbTest_CSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindDbTest_CSharp.DataAccess
{
    internal abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : class
    {
        /// <summary>
        /// The <see cref="HttpClient"/> used to make API calls.
        /// </summary>
        protected HttpClient _client;

        /// <summary>
        /// The <see cref="TaskFactory"/> used to make async calls in a synchronous method.
        /// </summary>
        protected TaskFactory _taskFactory;

        public BaseRepository() 
        { 
            _client = new HttpClient();
            _taskFactory = new TaskFactory(CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default);
        }

        public abstract string Endpoint { get; }

        /// <summary>
        /// Get all <typeparamref name="T"/> from the API.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return GetDataFromEndpoint<IEnumerable<T>>(Endpoint);
        }

        /// <summary>
        /// Get the <typeparamref name="T"/> from the API with the associated ID.
        /// </summary>
        /// <param name="id">The ID of the record to retrieve.</param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return GetDataFromEndpoint<T>($"{Endpoint}/{id}");
        }

        /// <summary>
        /// Get the <typeparamref name="T"/> from the API with the associated ID.
        /// </summary>
        /// <param name="stringId">The ID of the record to retrieve.</param>
        /// <returns></returns>
        public virtual T GetById(string stringId)
        {
            return GetDataFromEndpoint<T>($"{Endpoint}/{stringId}");
        }

        /// <summary>
        /// Make an API endpoint call and return the data that was retrieved.
        /// </summary>
        /// <typeparam name="TReturn">The return type of the data.</typeparam>
        /// <param name="endpoint">The API endpoint to call.</param>
        /// <returns>All data returned from the API endpoint call as <typeparamref name="TReturn"/>.</returns>
        protected TReturn GetDataFromEndpoint<TReturn>(string endpoint) where TReturn : class
        {
            TReturn data = default;

            using (HttpResponseMessage response = _taskFactory.RunAsyncWithResult(() => _client.GetAsync(endpoint)))
            {
                if (response.IsSuccessStatusCode)
                {
                    string json = _taskFactory.RunAsyncWithResult(() => response.Content.ReadAsStringAsync());

                    if (!string.IsNullOrEmpty(json))
                    {
                        data = JsonConvert.DeserializeObject<TReturn>(json);
                    }
                }
            }

            return data;
        }

        #region "IDisposable Pattern"
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (_client != null) 
                    { 
                        _client.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}