using DocGenerator.JsonSchema.ApiSchemaGenerators;
using Nest;

namespace DocGenerator.JsonSchema
{
	public class EndpointsGenerator : ApiSchemaGenerator
	{
		public override void Generate()
		{
			using(var schema = new ElasticsearchSchema("update"))
			{
				schema.Request<IUpdateRequest<object, object>>();
				schema.Response<IUpdateResponse>();
			}
			using(var schema = new ElasticsearchSchema("termvector"))
			{
				schema.Request<ITermvectorRequest>();
				schema.Response<ITermVectorResponse>();
			}
			using(var schema = new ElasticsearchSchema("suggest"))
			{
				schema.Request<ISuggestRequest>(); //uses custom json
				schema.Response<ISuggestResponse>();
			}
			using(var schema = new ElasticsearchSchema("snapshot.status"))
			{
				schema.Request<ISnapshotStatusRequest>();
				schema.Response<ISnapshotStatusResponse>();
			}
			using(var schema = new ElasticsearchSchema("snapshot.get_repository"))
			{
				schema.Request<IGetRepositoryRequest>();
				schema.Response<IGetRepositoryResponse>(); //uses custom converter
			}
			using(var schema = new ElasticsearchSchema("snapshot.get"))
			{
				schema.Request<IGetSnapshotRequest>();
				schema.Response<IGetSnapshotResponse>();
			}
			using(var schema = new ElasticsearchSchema("snapshot.delete_repository"))
			{
				schema.Request<IDeleteRepositoryRequest>();
				schema.Response<IAcknowledgedResponse>();
			}
			using(var schema = new ElasticsearchSchema("snapshot.delete"))
			{
				schema.Request<IDeleteSnapshotRequest>();
				schema.Response<IAcknowledgedResponse>();
			}
			using(var schema = new ElasticsearchSchema("snapshot.create_repository"))
			{
				schema.Request<ICreateRepositoryRequest>();
				schema.Response<IAcknowledgedResponse>();
			}
			using(var schema = new ElasticsearchSchema("snapshot.create"))
			{
				schema.Request<ISnapshotRequest>();
				schema.Response<ISnapshotResponse>();
			}
			using(var schema = new ElasticsearchSchema("search_template"))
			{
				schema.Request<ISearchTemplateRequest>();
				schema.Response<ISearchResponse<object>>();
			}
			using(var schema = new ElasticsearchSchema("search_shards"))
			{
				schema.Request<ISearchShardsRequest>();
				schema.Response<ISearchShardsResponse>();
			}
			using(var schema = new ElasticsearchSchema("search_exists"))
			{
				//TODO implement in NEST
			}
			using(var schema = new ElasticsearchSchema("search"))
			{
				schema.Request<ISearchRequest>();
				schema.Response<ISearchResponse<object>>();
			}
			using(var schema = new ElasticsearchSchema("scroll"))
			{
				schema.Request<IScrollRequest>();
				schema.Response<ISearchResponse<object>>();
			}
			using(var schema = new ElasticsearchSchema("put_template"))
			{
				schema.Request<IPutTemplateRequest>(); //actually sends request.TemplateMapping
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("put_script"))
			{
				//TODO Implement int NEST
			}
			using(var schema = new ElasticsearchSchema("ping"))
			{
				schema.Request<IPingRequest>();
				schema.Response<IPingResponse>();
			}
			using(var schema = new ElasticsearchSchema("percolate"))
			{
				schema.Request<IPercolateRequest<object>>();
				schema.Response<PercolateResponse>(); //implementation exposes more properties
			}
			using(var schema = new ElasticsearchSchema("nodes.stats"))
			{
				schema.Request<INodesStatsRequest>();
				schema.Response<INodeStatsResponse>();
			}
			using(var schema = new ElasticsearchSchema("nodes.shutdown"))
			{
				schema.Request<INodesShutdownRequest>();
				schema.Response<INodesShutdownResponse>(); //response.Nodes very weakly typed
			}
			using(var schema = new ElasticsearchSchema("nodes.info"))
			{
				schema.Request<INodesInfoRequest>();
				schema.Response<INodeInfoResponse>();
			}
			using(var schema = new ElasticsearchSchema("nodes.hot_threads"))
			{
				schema.Request<INodesHotThreadsRequest>(); 
				schema.Response<INodesHotThreadsResponse>(); //response is text we parse this manually
			}
			using(var schema = new ElasticsearchSchema("mtermvectors"))
			{
				schema.Request<IMultiTermVectorsRequest>();
				schema.Response<IMultiTermVectorResponse>();
			}
			using(var schema = new ElasticsearchSchema("msearch"))
			{
				schema.Request<IMultiSearchRequest>();
				schema.Response<IMultiSearchResponse>(); //custom converter
			}
			using(var schema = new ElasticsearchSchema("mpercolate"))
			{
				schema.Request<IMultiPercolateRequest>();
				schema.Response<IMultiPercolateResponse>(); //custom converter
			}
			using(var schema = new ElasticsearchSchema("mlt"))
			{
				schema.Request<IMoreLikeThisRequest>(); //sends request.Search
				schema.Response<ISearchResponse<object>>();
			}
			using(var schema = new ElasticsearchSchema("mget"))
			{
				schema.Request<IMultiGetRequest>();
				schema.Response<IMultiGetResponse>(); //custom converter
			}
			using(var schema = new ElasticsearchSchema("list_benchmarks"))
			{
				//TODO Implement in NEST
			}
			using(var schema = new ElasticsearchSchema("info"))
			{
				schema.Request<IInfoRequest>();
				schema.Response<IRootInfoResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.validate_query"))
			{
				schema.Request<IValidateQueryRequest>();
				schema.Response<IValidateResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.update_aliases"))
			{
				schema.Request<IAliasRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.stats"))
			{
				schema.Request<IIndicesStatsRequest>();
				schema.Response<IGlobalStatsResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.segments"))
			{
				schema.Request<ISegmentsRequest>();
				schema.Response<ISegmentsResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.refresh"))
			{
				schema.Request<IRefreshRequest>();
				schema.Response<IShardsOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.recovery"))
			{
				schema.Request<IRecoveryStatusRequest>();
				schema.Response<IRecoveryStatusResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.put_warmer"))
			{
				schema.Request<IPutWarmerRequest>(); //custom json converter
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.put_template"))
			{
				schema.Request<IPutTemplateRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.put_alias"))
			{
				schema.Request<IPutAliasRequest>();
				schema.Response<IPutAliasResponse>(); //does not seem to define anything (more generic response)?
			}
			using(var schema = new ElasticsearchSchema("indices.optimize"))
			{
				schema.Request<IOptimizeRequest>();
				schema.Response<IShardsOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.open"))
			{
				schema.Request<IOpenIndexRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.get_warmer"))
			{
				schema.Request<IGetWarmerRequest>();
				schema.Response<IWarmerResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.get_template"))
			{
				schema.Request<IGetTemplateRequest>();
				schema.Response<ITemplateResponse>(); //custom deserialization scheme
			}
			using(var schema = new ElasticsearchSchema("indices.get_settings"))
			{
				schema.Request<IGetIndexSettingsRequest>();
				schema.Response<IIndexSettingsResponse>(); //custom converter
			}
			using(var schema = new ElasticsearchSchema("indices.get_mapping"))
			{
				schema.Request<IGetMappingRequest>();
				schema.Response<IGetMappingResponse>(); //custom converter
			}
			using(var schema = new ElasticsearchSchema("indices.get_field_mapping"))
			{
				schema.Request<IGetFieldMappingRequest>();
				schema.Response<IGetFieldMappingResponse>(); //custom creation
			}
			using(var schema = new ElasticsearchSchema("indices.get_aliases"))
			{
				schema.Request<IGetAliasesRequest>();
				schema.Response<IGetAliasesResponse>(); //custom creation
			}
			using(var schema = new ElasticsearchSchema("indices.get_alias"))
			{
				schema.Request<IGetAliasRequest>();
				schema.Response<IGetAliasesResponse>(); //custom creation
			}
			using(var schema = new ElasticsearchSchema("indices.get"))
			{
				schema.Request<IGetRequest>();
				schema.Response<GetResponse<object>>(); //class because it uses internal untyped dict
			}
			using(var schema = new ElasticsearchSchema("indices.flush"))
			{
				schema.Request<IFlushRequest>();
				schema.Response<IShardsOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.exists_type"))
			{
				schema.Request<ITypeExistsRequest>();
				schema.Response<IExistsResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.exists_alias"))
			{
				schema.Request<IAliasExistsRequest>();
				schema.Response<IExistsResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.exists"))
			{
				schema.Request<IIndexExistsRequest>();
				schema.Response<IExistsResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.delete_warmer"))
			{
				schema.Request<IDeleteWarmerRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.delete_template"))
			{
				schema.Request<IDeleteTemplateRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.delete_mapping"))
			{
				schema.Request<IDeleteMappingRequest>();
				schema.Response<IIndicesResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.delete_alias"))
			{
				schema.Request<IDeleteAliasRequest>();
				schema.Response<IDeleteAliasResponse>(); //empty class (more generic??)
			}
			using(var schema = new ElasticsearchSchema("indices.delete"))
			{
				schema.Request<IDeleteIndexRequest>();
				schema.Response<IIndicesResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.create"))
			{
				schema.Request<ICreateIndexRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.close"))
			{
				schema.Request<ICloseIndexRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.clear_cache"))
			{
				schema.Request<IClearCacheRequest>();
				schema.Response<IShardsOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("indices.analyze"))
			{
				schema.Request<IAnalyzeRequest>();
				schema.Response<IAnalyzeResponse>();
			}
			using(var schema = new ElasticsearchSchema("index"))
			{
				schema.Request<IIndexRequest<object>>();
				schema.Response<IIndexResponse>();
			}
			using(var schema = new ElasticsearchSchema("get_template"))
			{
				schema.Request<IGetTemplateRequest>();
				schema.Response<ITemplateResponse>(); //custom
			}
			using(var schema = new ElasticsearchSchema("get_source"))
			{
				schema.Request<ISourceRequest>();
			}
			using(var schema = new ElasticsearchSchema("get_script"))
			{
				//TODO implement in NEST
			}
			using(var schema = new ElasticsearchSchema("get"))
			{
				schema.Request<IGetRequest>();
				schema.Response<GetResponse<object>>(); //class because fields is weaker typed there
			}
			using(var schema = new ElasticsearchSchema("explain"))
			{
				schema.Request<IExplainRequest>();
				schema.Response<IExplainResponse<object>>();
			}
			using(var schema = new ElasticsearchSchema("exists"))
			{
				schema.Request<IDocumentExistsRequest>();
				schema.Response<IExistsResponse>();
			}
			using(var schema = new ElasticsearchSchema("delete_template"))
			{
				schema.Request<IDeleteTemplateRequest>();
				schema.Response<IIndicesOperationResponse>();
			}
			using(var schema = new ElasticsearchSchema("delete_script"))
			{
				//TODO implement in NEST
			}
			using(var schema = new ElasticsearchSchema("delete_by_query"))
			{
				schema.Request<IDeleteByQueryRequest>();
				schema.Response<IDeleteResponse>();
			}
			using(var schema = new ElasticsearchSchema("delete"))
			{
				schema.Request<IDeleteRequest>();
				schema.Response<IDeleteResponse>();
			}
			using(var schema = new ElasticsearchSchema("count_percolate"))
			{
				schema.Request<IPercolateCountRequest<object>>();
				schema.Response<IPercolateCountResponse>();
			}
			using(var schema = new ElasticsearchSchema("count"))
			{
				schema.Request<ICountRequest>();
				schema.Response<ICountResponse>();
			}
			using(var schema = new ElasticsearchSchema("cluster.stats"))
			{
				schema.Request<IClusterStatsRequest>();
				schema.Response<IClusterStatsResponse>();
			}
			using(var schema = new ElasticsearchSchema("cluster.state"))
			{
				schema.Request<IClusterStateRequest>();
				schema.Response<IClusterStateResponse>();
			}
			using(var schema = new ElasticsearchSchema("cluster.reroute"))
			{
				//TODO Implement in NEST
			}
			using(var schema = new ElasticsearchSchema("cluster.put_settings"))
			{
				schema.Request<IClusterSettingsRequest>();
				schema.Response<IClusterPutSettingsResponse>();
			}
			using(var schema = new ElasticsearchSchema("cluster.pending_tasks"))
			{
				schema.Request<IClusterPendingTasksRequest>();
				schema.Response<IClusterPendingTasksResponse>();
			}
			using(var schema = new ElasticsearchSchema("cluster.health"))
			{
				schema.Request<IClusterHealthRequest>();
				schema.Response<IHealthResponse>();
			}
			using(var schema = new ElasticsearchSchema("cluster.get_settings"))
			{
				schema.Request<IClusterGetSettingsRequest>();
				schema.Response<IClusterGetSettingsResponse>();
			}
			using(var schema = new ElasticsearchSchema("clear_scroll"))
			{
				schema.Request<IClearScrollRequest>();
				schema.Response<IEmptyResponse>();
			}
			using(var schema = new ElasticsearchSchema("cat.thread_pool"))
			{
				schema.Request<ICatThreadPoolRequest>(); //actually returns array we normalize to .Records
				schema.Response<ICatResponse<CatThreadPoolRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.shards"))
			{
				schema.Request<ICatShardsRequest>();
				schema.Response<ICatResponse<CatShardsRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.recovery"))
			{
				schema.Request<ICatRecoveryRequest>();
				schema.Response<ICatResponse<CatRecoveryRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.plugins"))
			{
				schema.Request<ICatPluginsRequest>();
				schema.Response<ICatResponse<CatPluginsRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.pending_tasks"))
			{
				schema.Request<ICatPendingTasksRequest>();
				schema.Response<ICatResponse<CatPendingTasksRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.nodes"))
			{
				schema.Request<ICatNodesRequest>();
				schema.Response<ICatResponse<CatNodesRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.nodes"))
			{
				schema.Request<ICatNodesRequest>();
				schema.Response<ICatResponse<CatNodesRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.master"))
			{
				schema.Request<ICatMasterRequest>();
				schema.Response<ICatResponse<CatMasterRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.indices"))
			{
				schema.Request<ICatIndicesRequest>();
				schema.Response<ICatResponse<CatIndicesRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.help"))
			{
				//TODO Implement in NEST
			}
			using(var schema = new ElasticsearchSchema("cat.health"))
			{
				schema.Request<ICatHealthRequest>();
				schema.Response<ICatResponse<CatHealthRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.fielddata"))
			{
				schema.Request<ICatFielddataRequest>();
				schema.Response<ICatResponse<CatFielddataRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.count"))
			{
				schema.Request<ICatCountRequest>();
				schema.Response<ICatResponse<CatCountRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.allocation"))
			{
				schema.Request<ICatAllocationRequest>();
				schema.Response<ICatResponse<CatAllocationRecord>>();
			}
			using(var schema = new ElasticsearchSchema("cat.aliases"))
			{
				schema.Request<ICatAliasesRequest>();
				schema.Response<ICatResponse<CatAliasesRecord>>();
			}
			using(var schema = new ElasticsearchSchema("bulk"))
			{
				schema.Request<IBulkRequest>();
				schema.Response<IBulkResponse>();
			}
			using(var schema = new ElasticsearchSchema("benchmark"))
			{
				//TODO Implement in NEST 
			}
			using(var schema = new ElasticsearchSchema("abort_benchmark"))
			{
				//TODO implement in NEST
			}
		}
	}
}