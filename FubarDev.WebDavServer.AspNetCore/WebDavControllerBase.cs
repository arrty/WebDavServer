﻿using System;
using System.Threading;
using System.Threading.Tasks;

using FubarDev.WebDavServer.AspNetCore.Routing;
using FubarDev.WebDavServer.Model;

using Microsoft.AspNetCore.Mvc;

namespace FubarDev.WebDavServer.AspNetCore
{
    public class WebDavControllerBase : ControllerBase
    {
        private IWebDavDispatcher _dispatcher;

        public WebDavControllerBase(IWebDavDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpOptions]
        public  async Task<IActionResult> QueryOptionsAsync(string path, CancellationToken cancellationToken)
        {
            var result = await _dispatcher.Class1.OptionsAsync(path, cancellationToken).ConfigureAwait(false);
            return new WebDavIndirectResult(_dispatcher, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string path, CancellationToken cancellationToken)
        {
            var result = await _dispatcher.Class1.GetAsync(path, cancellationToken).ConfigureAwait(false);
            return new WebDavIndirectResult(_dispatcher, result);
        }

        // POST api/values
        [HttpPost]
        public Task PostAsync(string path, [FromBody]string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        [HttpPut]
        public Task PutAsync(string path, [FromBody]string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete()]
        public Task DeleteAsync(string path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPropFind()]
        public async Task<IActionResult> PropFindAsync(string path, [FromBody]Propfind request, [FromHeader(Name = "Depth")] string depth, CancellationToken cancellationToken)
        {
            var parsedDepth = Depth.Parse(depth);
            var result = await _dispatcher.Class1.PropFindAsync(path, request, parsedDepth, cancellationToken).ConfigureAwait(false);
            return new WebDavIndirectResult(_dispatcher, result);
        }

        [HttpPropPatch]
        public Task PropPatchAsync(string path, [FromBody]string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpHead]
        public async Task<IActionResult> HeadAsync(string path, [FromBody]string value, CancellationToken cancellationToken)
        {
            var result = await _dispatcher.Class1.HeadAsync(path, cancellationToken).ConfigureAwait(false);
            return new WebDavIndirectResult(_dispatcher, result);
        }

        [HttpCopy]
        public Task<IActionResult> CopyAsync(string path, [FromBody]string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpMove]
        public Task<IActionResult> MoveAsync(string path, [FromBody]string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}