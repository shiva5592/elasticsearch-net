using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nest
{
	public class BulkResponse : BaseResponse, IBulkResponse
	{
		private bool _isValid;
		public override bool IsValid
		{
			get
			{
				return this._isValid && !this.Errors && !this.ItemsWithErrors.HasAny();
			}
			internal set
			{
				this._isValid = value;
			}
		}

		public int Took { get; internal set; }

		public bool Errors { get; internal set; }

		public IEnumerable<BulkOperationResponseItem> Items { get; internal set; }

		public IEnumerable<BulkOperationResponseItem> ItemsWithErrors
		{
			get
			{
				return !this.Items.HasAny() ? Enumerable.Empty<BulkOperationResponseItem>() : this.Items.Where(i => !i.IsValid);
			}
		}
	}
}
