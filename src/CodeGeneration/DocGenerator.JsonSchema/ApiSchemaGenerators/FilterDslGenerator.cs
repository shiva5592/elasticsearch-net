using DocGenerator.JsonSchema.ApiSchemaGenerators;
using Nest;

namespace DocGenerator.JsonSchema
{
	public class FilterDslGenerator : ApiSchemaGenerator
	{
		public override void Generate()
		{
			using(var schema = new ElasticsearchSchema(@"_domain\filter-dsl"))
			{
				schema.Domain<IFilterContainer>();
				schema.Domain<IBoolFilter>();
				schema.Domain<IExistsFilter>();
				schema.Domain<IMissingFilter>();
				schema.Domain<IIdsFilter>();
				schema.Domain<IGeoBoundingBoxFilter>();
				schema.Domain<IGeoDistanceFilter>();
				schema.Domain<IGeoPolygonFilter>();
				schema.Domain<IGeoIndexedShapeFilter>();
				schema.Domain<IGeoShapeCircleFilter>();
				schema.Domain<IGeoShapeEnvelopeFilter>();
				schema.Domain<IGeoShapeLineStringFilter>();
				schema.Domain<IGeoShapeMultiLineStringFilter>();
				schema.Domain<IGeoShapeMultiPointFilter>();
				schema.Domain<IGeoShapePointFilter>();
				schema.Domain<IGeoShapePolygonFilter>();
				schema.Domain<ILimitFilter>();
				schema.Domain<ITypeFilter>();
				schema.Domain<IMatchAllFilter>();
				schema.Domain<IHasChildFilter>();
				schema.Domain<IHasParentFilter>();
				schema.Domain<IRangeFilter>();
				schema.Domain<IPrefixFilter>();
				schema.Domain<ITermFilter>();
				schema.Domain<ITermsFilter>();
				schema.Domain<ITermsLookupFilter>();
				schema.Domain<IQueryFilter>();
				schema.Domain<IAndFilter>();
				schema.Domain<IOrFilter>();
				schema.Domain<INotFilter>();
				schema.Domain<IScriptFilter>();
				schema.Domain<INestedFilter>();
				schema.Domain<IRegexpFilter>();
			}
		}
	}
}