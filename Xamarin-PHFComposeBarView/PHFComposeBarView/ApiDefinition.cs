using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PHFComposeBarView {

  interface ComposeBarViewDidChangeFrameEventArgs {

    [Export ("PHFComposeBarViewFrameBeginUserInfoKey", ArgumentSemantic.Assign)]
    RectangleF FrameBegin { get; }

    [Export ("PHFComposeBarViewFrameEndUserInfoKey", ArgumentSemantic.Assign)]
    RectangleF FrameEnd { get; }
  }

  interface ComposeBarViewViewWillChangeFrameEventArgs {

    [Export ("PHFComposeBarViewFrameBeginUserInfoKey", ArgumentSemantic.Assign)]
    RectangleF FrameBegin { get; }

    [Export ("PHFComposeBarViewFrameEndUserInfoKey", ArgumentSemantic.Assign)]
    RectangleF FrameEnd { get; }

    [Export ("PHFComposeBarViewAnimationDurationUserInfoKey", ArgumentSemantic.Assign)]
    double AnimationDuration { get; }

    [Export ("PHFComposeBarViewAnimationCurveUserInfoKey", ArgumentSemantic.Assign)]
    int AnimationCurve { get; }
  }

//  [BaseType (typeof (UITextView))]
//  public partial interface PHFComposeBarView_TextView {
//
//    [Export ("PHFComposeBarView_setContentOffset:")]
//    void SetContentOffset (PointF contentOffset);
//
//  }

  [BaseType (typeof (UIView), Name = "PHFComposeBarView", 
    Delegates=new string [] { "WeakDelegate" }, 
    Events=new Type [] {typeof(ComposeBarViewDelegate) })]

   interface ComposeBarView {


    [Field ("PHFComposeBarViewInitialHeight", "__Internal")]
    float InitialHeight { get; }

    [Notification, Field ("PHFComposeBarViewDidChangeFrameNotification", "__Internal")]
    NSString DidChangeFrameNotification { get; }

    [Notification, Field ("PHFComposeBarViewWillChangeFrameNotification", "__Internal")]
    NSString WillChangeFrameNotification { get; }

    [Export ("initWithFrame:")]
    IntPtr Constructor (RectangleF frame);


    [Export ("autoAdjustTopOffset")]
    bool AutoAdjustTopOffset { get; set; }

    [Export ("button", ArgumentSemantic.Retain)]
    UIButton Button { get; }

    [Export ("buttonTintColor", ArgumentSemantic.Retain)]
    UIColor ButtonTintColor { get; set; }

    [Export ("buttonTitle", ArgumentSemantic.Retain)]
    string ButtonTitle { get; set; }

    [Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
    NSObject WeakDelegate { get; set; }

    [Wrap ("WeakDelegate")]
    ComposeBarViewDelegate Delegate { get; set; }

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

  [BaseType (typeof (NSObject), Name = "PHFComposeBarViewDelegate")]
  [Model]
  [Protocol]
  interface ComposeBarViewDelegate {


    [Export ("composeBarViewDidPressButton:"), EventArgs ("ComposeBarViewArgs")]
    void DidPressButton (ComposeBarView composeBarView);

    [Export ("composeBarViewDidPressUtilityButton:"), EventArgs ("ComposeBarViewArgs")]
    void DidPressUtilityButton (ComposeBarView composeBarView);

    [Export ("composeBarView:willChangeFromFrame:toFrame:duration:animationCurve:"), EventArgs ("ComposeBarViewFrameAnimationArgs")]
    void WillChangeFrameSize (ComposeBarView composeBarView, RectangleF startFrame, RectangleF endFrame, double duration, UIViewAnimationCurve animationCurve);

    [Export ("composeBarView:didChangeFromFrame:toFrame:"), EventArgs ("ComposeBarViewFrameArgs")]
    void DidChangeFrameSize (ComposeBarView composeBarView, RectangleF startFrame, RectangleF endFrame);

    // UITextViewDelegate

    [Export ("textViewShouldBeginEditing:"), DelegateName ("ComposeBarViewTextViewCondition"), DefaultValue ("true")]
    bool ShouldBeginEditing (UITextView textView);

    [Export ("textViewShouldEndEditing:"), DelegateName ("ComposeBarViewTextViewCondition"), DefaultValue ("true")]
    bool ShouldEndEditing (UITextView textView);

    [Export ("textViewDidBeginEditing:"), EventArgs ("ComposeBarViewTextView"), EventName ("Started")]
    void EditingStarted (UITextView textView);

    [Export ("textViewDidEndEditing:"), EventArgs ("ComposeBarViewTextView"), EventName ("Ended")]
    void EditingEnded (UITextView textView);

    [Export ("textView:shouldChangeTextInRange:replacementText:"), DelegateName ("ComposeBarViewTextViewChange"), DefaultValue ("true")]
    bool ShouldChangeText (UITextView textView, NSRange range, string text);

    [Export ("textViewDidChange:"), EventArgs ("ComposeBarViewTextView")]
    void Changed (UITextView textView);

    [Export ("textViewDidChangeSelection:"), EventArgs ("ComposeBarViewTextView")]
    void SelectionChanged (UITextView textView);

  }
}
