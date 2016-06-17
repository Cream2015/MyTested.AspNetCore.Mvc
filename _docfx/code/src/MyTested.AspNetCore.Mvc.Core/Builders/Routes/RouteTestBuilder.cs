﻿namespace MyTested.AspNetCore.Mvc.Builders.Routes
{
    using System;
    using Contracts.Http;
    using Contracts.Routes;
    using Http;
    using Internal.Http;
    using Internal.TestContexts;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Used for building a route test.
    /// </summary>
    public class RouteTestBuilder : BaseRouteTestBuilder, IRouteTestBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteTestBuilder"/> class.
        /// </summary>
        /// <param name="testContext"><see cref="RouteTestContext"/> containing data about the currently executed assertion chain.</param>
        public RouteTestBuilder(RouteTestContext testContext)
            : base(testContext)
        {
        }

        private MockedHttpContext HttpContext => this.TestContext.MockedHttpContext;

        /// <inheritdoc />
        public IShouldMapTestBuilder ShouldMap(string location)
        {
            return this.ShouldMap(request => request
                .WithLocation(location)
                .WithMethod(HttpMethod.Get));
        }

        /// <inheritdoc />
        public IShouldMapTestBuilder ShouldMap(Uri location)
        {
            return this.ShouldMap(request => request
                .WithLocation(location)
                .WithMethod(HttpMethod.Get));
        }

        /// <inheritdoc />
        public IShouldMapTestBuilder ShouldMap(HttpRequest request)
        {
            this.HttpContext.CustomRequest = request;
            return this.ShouldMap(this.HttpContext);
        }

        /// <inheritdoc />
        public IShouldMapTestBuilder ShouldMap(Action<IHttpRequestBuilder> httpRequestBuilder)
        {
            var httpBuilder = new HttpRequestBuilder(this.HttpContext);
            httpRequestBuilder(httpBuilder);
            httpBuilder.ApplyTo(this.HttpContext.Request);
            return this.ShouldMap(this.HttpContext);
        }

        private IShouldMapTestBuilder ShouldMap(HttpContext httpContext)
        {
            return new ShouldMapTestBuilder(this.TestContext);
        }
    }
}
