namespace Belin.Akismet;

/// <summary>
/// Specifies the result of a comment check.
/// </summary>
public enum CheckResult {

	/// <summary>
	/// The comment is a ham.
	/// </summary>
	Ham,

	/// <summary>
	/// The comment is a spam.
	/// </summary>
	Spam,

	/// <summary>
	/// The comment is a pervasive spam (i.e. it can be safely discarded).
	/// </summary>
	PervasiveSpam
}
