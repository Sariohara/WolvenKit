
namespace WolvenKit.RED4.Types
{
	public partial class gamedataWeaponManufacturer_Record
	{
		[RED("name")]
		[REDProperty(IsIgnored = true)]
		public CString Name
		{
			get => GetPropertyValue<CString>();
			set => SetPropertyValue<CString>(value);
		}
	}
}
