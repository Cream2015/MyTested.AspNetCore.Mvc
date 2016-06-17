﻿namespace MyTested.AspNetCore.Mvc.Builders.Contracts.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// Used for testing <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/>.
    /// </summary>
    public interface IViewBagTestBuilder
    {
        /// <summary>
        /// Tests whether the <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/> contains entry with the provided key.
        /// </summary>
        /// <param name="key">Key of the view bag entry.</param>
        /// <returns>The same <see cref="IAndViewBagTestBuilder"/>.</returns>
        IAndViewBagTestBuilder ContainingEntryWithKey(string key);

        /// <summary>
        /// Tests whether the <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/> contains entry with the provided value.
        /// </summary>
        /// <typeparam name="TEntry">Type of the view bag entry value.</typeparam>
        /// <param name="value">Value of the view bag entry.</param>
        /// <returns>The same <see cref="IAndViewBagTestBuilder"/>.</returns>
        IAndViewBagTestBuilder ContainingEntryWithValue<TEntry>(TEntry value);

        /// <summary>
        /// Tests whether the <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/> contains entry with value of the provided type.
        /// </summary>
        /// <typeparam name="TEntry">Type of the view bag entry value.</typeparam>
        /// <returns>The same <see cref="IAndViewBagTestBuilder"/>.</returns>
        IAndViewBagTestBuilder ContainingEntryOfType<TEntry>();

        /// <summary>
        /// Tests whether the <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/> contains entry with value of the provided type and the given key.
        /// </summary>
        /// <typeparam name="TEntry">Type of the view bag entry value.</typeparam>
        /// <param name="key">Key of the view bag entry.</param>
        /// <returns>The same <see cref="IAndViewBagTestBuilder"/>.</returns>
        IAndViewBagTestBuilder ContainingEntryOfType<TEntry>(string key);

        /// <summary>
        /// Tests whether the <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/> contains entry with the provided key and corresponding value.
        /// </summary>
        /// <param name="key">Key of the view bag entry.</param>
        /// <param name="value">Value of the view bag entry.</param>
        /// <returns>The same <see cref="IAndViewBagTestBuilder"/>.</returns>
        IAndViewBagTestBuilder ContainingEntry(string key, object value);

        /// <summary>
        /// Tests whether the <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/> contains the provided entries. 
        /// </summary>
        /// <param name="entries">Anonymous object of view bag entries.</param>
        /// <returns>The same <see cref="IAndViewBagTestBuilder"/>.</returns>
        IAndViewBagTestBuilder ContainingEntries(object entries);

        /// <summary>
        /// Tests whether the <see cref="Microsoft.AspNetCore.Mvc.Controller.ViewBag"/> contains the provided entries. 
        /// </summary>
        /// <param name="entries">Dictionary of view bag entries.</param>
        /// <returns>The same <see cref="IAndViewBagTestBuilder"/>.</returns>
        IAndViewBagTestBuilder ContainingEntries(IDictionary<string, object> entries);
    }
}
