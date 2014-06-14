using System.Drawing;
using System;

namespace PHFComposeBarView {

	[BaseType (typeof (UITextView))]
	public partial interface PHFComposeBarView_TextView {

		[Export ("PHFComposeBarView_setContentOffset:")]
		void PHFComposeBarView_setContentOffset (PointF contentOffset);

		[Field ("PHFComposeBarViewInitialHeight")]
		CGFloat PHFComposeBarViewInitialHeight { get; }

		[Notification, Field ("PHFComposeBarViewDidChangeFrameNotification")]
		NSString PHFComposeBarViewDidChangeFrameNotification { get; }

		[Notification, Field ("PHFComposeBarViewWillChangeFrameNotification")]
		NSString PHFComposeBarViewWillChangeFrameNotification { get; }

		[Field ("PHFComposeBarViewAnimationDurationUserInfoKey")]
		NSString PHFComposeBarViewAnimationDurationUserInfoKey { get; }

		[Field ("PHFComposeBarViewAnimationCurveUserInfoKey")]
		NSString PHFComposeBarViewAnimationCurveUserInfoKey { get; }

		[Field ("PHFComposeBarViewFrameBeginUserInfoKey")]
		NSString PHFComposeBarViewFrameBeginUserInfoKey { get; }

		[Field ("PHFComposeBarViewFrameEndUserInfoKey")]
		NSString PHFComposeBarViewFrameEndUserInfoKey { get; }
	}

	[BaseType (typeof (UIView))]
	public partial interface PHFComposeBarView : UITextViewDelegate {

		[Export ("autoAdjustTopOffset")]
		bool AutoAdjustTopOffset { get; set; }

		[Export ("button", ArgumentSemantic.Retain)]
		UIButton Button { get; }

		[Export ("buttonTintColor", ArgumentSemantic.Retain)]
		UIColor ButtonTintColor { get; set; }

		[Export ("buttonTitle", ArgumentSemantic.Retain)]
		string ButtonTitle { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		PHFComposeBarViewDelegate Delegate { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("maxCharCount")]
		uint MaxCharCount { get; set; }

		[Export ("maxHeight")]
		float MaxHeight { get; set; }

		[Export ("maxLinesCount")]
		float MaxLinesCount { get; set; }

		[Export ("placeholder", ArgumentSemantic.Retain)]
		string Placeholder { get; set; }

		[Export ("placeholderLabel")]
		UILabel PlaceholderLabel { get; }

		[Export ("text", ArgumentSemantic.Retain)]
		string Text { get; set; }

		[Export ("textView", ArgumentSemantic.Retain)]
		UITextView TextView { get; }

		[Export ("utilityButton", ArgumentSemantic.Retain)]
		UIButton UtilityButton { get; }

		[Export ("utilityButtonImage", ArgumentSemantic.Retain)]
		UIImage UtilityButtonImage { get; set; }

		[Export ("setText:animated:")]
		void SetText (string text, bool animated);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface PHFComposeBarViewDelegate : UITextViewDelegate {

		[Export ("composeBarViewDidPressButton:")]
		void  (PHFComposeBarView composeBarView);

		[Export ("composeBarViewDidPressUtilityButton:")]
		void  (PHFComposeBarView composeBarView);

		[Export ("composeBarView:willChangeFromFrame:toFrame:duration:animationCurve:")]
		void WillChangeFromFrame (PHFComposeBarView composeBarView, RectangleF startFrame, RectangleF endFrame, double duration, UIViewAnimationCurve animationCurve);

		[Export ("composeBarView:didChangeFromFrame:toFrame:")]
		void DidChangeFromFrame (PHFComposeBarView composeBarView, RectangleF startFrame, RectangleF endFrame);
	}
}
