﻿namespace MyTested.AspNetCore.Mvc.Builders.Contracts.Actions
{
    using System;
    using And;
    using Attributes;
    using Base;
    using Http;
    using Models;

    /// <summary>
    /// Used for testing the action's additional data - action attributes, HTTP response, view bag and more.
    /// </summary>
    /// <typeparam name="TActionResult">Result from invoked action in ASP.NET Core MVC controller.</typeparam>
    public interface IShouldHaveTestBuilder<TActionResult> : IBaseTestBuilderWithActionResult<TActionResult>
    {
        /// <summary>
        /// Tests whether the action has no attributes of any type. 
        /// </summary>
        /// <returns>Test builder of <see cref="IAndTestBuilder{TActionResult}"/> type.</returns>
        IAndTestBuilder<TActionResult> NoActionAttributes();

        /// <summary>
        /// Tests whether the action has at least 1 attribute of any type. 
        /// </summary>
        /// <param name="withTotalNumberOf">Optional parameter specifying the exact total number of attributes on the tested action.</param>
        /// <returns>Test builder of <see cref="IAndTestBuilder{TActionResult}"/> type.</returns>
        IAndTestBuilder<TActionResult> ActionAttributes(int? withTotalNumberOf = null);

        /// <summary>
        /// Tests whether the action has specific attributes. 
        /// </summary>
        /// <param name="attributesTestBuilder">Builder for testing specific attributes on the action.</param>
        /// <returns>Test builder of <see cref="IAndTestBuilder{TActionResult}"/> type.</returns>
        IAndTestBuilder<TActionResult> ActionAttributes(Action<IActionAttributesTestBuilder> attributesTestBuilder);
        
        /// <summary>
        /// Tests whether the action applies additional features to the <see cref="Microsoft.AspNetCore.Http.HttpResponse"/>.
        /// </summary>
        /// <param name="httpResponseTestBuilder">Builder for testing the <see cref="Microsoft.AspNetCore.Http.HttpResponse"/>.</param>
        /// <returns>Test builder of <see cref="IAndTestBuilder{TActionResult}"/> type.</returns>
        IAndTestBuilder<TActionResult> HttpResponse(Action<IHttpResponseTestBuilder> httpResponseTestBuilder);
    }
}
