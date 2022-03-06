
namespace WolvenKit.RED4.Types
{
	public partial class gamedataUpgradingData_Record
	{
		[RED("ingredients")]
		[REDProperty(IsIgnored = true)]
		public CArray<TweakDBID> Ingredients
		{
			get => GetPropertyValue<CArray<TweakDBID>>();
			set => SetPropertyValue<CArray<TweakDBID>>(value);
		}
	}
}
