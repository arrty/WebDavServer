﻿// <copyright file="EntryExtensions.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;

using FubarDev.WebDavServer.FileSystem;
using FubarDev.WebDavServer.Props.Live;

namespace FubarDev.WebDavServer.Props
{
    public static class EntryExtensions
    {
        public static ILiveProperty GetResourceTypeProperty(this IEntry entry)
        {
            var coll = entry as ICollection;

            if (coll != null)
                return ResourceTypeProperty.GetCollectionResourceType();

            var doc = entry as IDocument;
            if (doc != null)
                return ResourceTypeProperty.GetDocumentResourceType();

            throw new NotSupportedException();
        }
    }
}