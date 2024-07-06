// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.PowerBI.Api.Models;

namespace Microsoft.PowerBI.Api
{
    internal partial class ReportsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ReportsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public ReportsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://api.powerbi.com");
        }

        internal HttpMessage CreateGetReportsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1.0/myorg/reports", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Returns a list of reports from **My workspace**. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// This API also returns shared reports and reports from shared apps. Reports that reside in shared workspaces can be accessed using the [Get Reports In Group API](/rest/api/power-bi/reports/get-reports-in-group).
        ///
        /// Since paginated reports (RDL) don't have a dataset, the dataset ID value in the API response for paginated reports isn't displayed.
        ///
        /// ## Required Scope
        ///
        /// Report.ReadWrite.All or Report.Read.All
        /// &lt;br&gt;&lt;br&gt;
        /// </remarks>
        public async Task<Response<Reports>> GetReportsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetReportsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Reports value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Reports.DeserializeReports(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Returns a list of reports from **My workspace**. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// This API also returns shared reports and reports from shared apps. Reports that reside in shared workspaces can be accessed using the [Get Reports In Group API](/rest/api/power-bi/reports/get-reports-in-group).
        ///
        /// Since paginated reports (RDL) don't have a dataset, the dataset ID value in the API response for paginated reports isn't displayed.
        ///
        /// ## Required Scope
        ///
        /// Report.ReadWrite.All or Report.Read.All
        /// &lt;br&gt;&lt;br&gt;
        /// </remarks>
        public Response<Reports> GetReports(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetReportsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Reports value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Reports.DeserializeReports(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetExportToFileStatusRequest(Guid reportId, string exportId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1.0/myorg/reports/", false);
            uri.AppendPath(reportId, true);
            uri.AppendPath("/exports/", false);
            uri.AppendPath(exportId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Returns the current status of the [Export to File](/rest/api/power-bi/reports/export-to-file) job for the specified report from **My workspace**. </summary>
        /// <param name="reportId"> The report ID. </param>
        /// <param name="exportId"> The export ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportId"/> is null. </exception>
        /// <remarks>
        /// When the export job status is 'Succeeded' use the [GetFileOfExportToFile API](/rest/api/power-bi/reports/get-file-of-export-to-file) to retrieve the file.
        ///
        /// ## Required Scope
        ///
        /// Report.ReadWrite.All or Report.Read.All
        /// &lt;br&gt;&lt;br&gt;
        /// </remarks>
        public async Task<Response<Export>> GetExportToFileStatusAsync(Guid reportId, string exportId, CancellationToken cancellationToken = default)
        {
            if (exportId == null)
            {
                throw new ArgumentNullException(nameof(exportId));
            }

            using var message = CreateGetExportToFileStatusRequest(reportId, exportId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    {
                        Export value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Export.DeserializeExport(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Returns the current status of the [Export to File](/rest/api/power-bi/reports/export-to-file) job for the specified report from **My workspace**. </summary>
        /// <param name="reportId"> The report ID. </param>
        /// <param name="exportId"> The export ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportId"/> is null. </exception>
        /// <remarks>
        /// When the export job status is 'Succeeded' use the [GetFileOfExportToFile API](/rest/api/power-bi/reports/get-file-of-export-to-file) to retrieve the file.
        ///
        /// ## Required Scope
        ///
        /// Report.ReadWrite.All or Report.Read.All
        /// &lt;br&gt;&lt;br&gt;
        /// </remarks>
        public Response<Export> GetExportToFileStatus(Guid reportId, string exportId, CancellationToken cancellationToken = default)
        {
            if (exportId == null)
            {
                throw new ArgumentNullException(nameof(exportId));
            }

            using var message = CreateGetExportToFileStatusRequest(reportId, exportId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    {
                        Export value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Export.DeserializeExport(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}