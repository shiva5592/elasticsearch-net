using DocGenerator.JsonSchema.ApiSchemaGenerators;
using Nest;

namespace DocGenerator.JsonSchema
{
	public class QueryDslGenerator : ApiSchemaGenerator
	{
		public override void Generate()
		{
			using(var schema = new ElasticsearchSchema(@"_domain\query-dsl"))
			{
				schema.Domain<IQueryContainer>();
				schema.Domain<IMatchAllQuery>();
				schema.Domain<ITermQuery>();
				schema.Domain<IWildcardQuery>();
				schema.Domain<IPrefixQuery>();
				schema.Domain<IBoostingQuery>();
				schema.Domain<IIdsQuery>();
				schema.Domain<ICustomScoreQuery>();
				schema.Domain<ICustomFiltersScoreQuery>();
				schema.Domain<ICustomBoostFactorQuery>();
				schema.Domain<IConstantScoreQuery>();
				schema.Domain<IDisMaxQuery>();
				schema.Domain<IFilteredQuery>();
				schema.Domain<IMultiMatchQuery>();
				schema.Domain<IMatchQuery>();
				schema.Domain<IFuzzyQuery>();
				schema.Domain<IGeoShapeQuery>();
				schema.Domain<ICommonTermsQuery>();
				schema.Domain<ITermsQuery>();
				schema.Domain<IRangeQuery>();
				schema.Domain<IRegexpQuery>();
				schema.Domain<IHasChildQuery>();
				schema.Domain<IHasParentQuery>();
				schema.Domain<ISpanTermQuery>();
				schema.Domain<IFuzzyLikeThisQuery>();
				schema.Domain<ISimpleQueryStringQuery>();
				schema.Domain<IQueryStringQuery>();
				schema.Domain<IMoreLikeThisQuery>();
				schema.Domain<ISpanFirstQuery>();
				schema.Domain<ISpanOrQuery>();
				schema.Domain<ISpanNearQuery>();
				schema.Domain<ISpanNotQuery>();
				schema.Domain<ISpanMultiTermQuery>();
				schema.Domain<ITopChildrenQuery>();
				schema.Domain<INestedQuery>();
				schema.Domain<IIndicesQuery>();
				schema.Domain<IFunctionScoreQuery>();
				schema.Domain<ITemplateQuery>();
			}
		}
	}
}