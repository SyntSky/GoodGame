using System.ComponentModel;

namespace SyntSky.GoodGame.Client.Enums;

public enum ChatColor
{
	[Description("simple")]
	Simple,

	[Description("streamer")]
	Streamer,

	[Description("bronze")]
	Bronze,

	[Description("silver")]
	Silver,

	[Description("diamond")]
	Diamond,

	[Description("king")]
	King,

	[Description("premium")]
	Premium,

	[Description("premium-personal")]
	PremiumPersonal,

	[Description("gold")]
	Gold
}