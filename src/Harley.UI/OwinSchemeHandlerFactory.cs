namespace eVision.Desktop.UI
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CefSharp;

    internal class OwinSchemeHandlerFactory : ISchemeHandlerFactory
    {
        private readonly Func<IDictionary<string, object>, Task> _appFunc;

        public OwinSchemeHandlerFactory(Func<IDictionary<string, object>, Task> appFunc)
        {
            _appFunc = appFunc;
        }

        public ISchemeHandler Create()
        {
            return new OwinSchemeHandler(_appFunc);
        }
    }
}