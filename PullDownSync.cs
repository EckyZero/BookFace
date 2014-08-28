

/**
 * @author Pushpan
 * @date Nov 27, 2012
 **/
using Android.Widget;
using Android.Views;
using Android.Content;


namespace BookFace {
	public class PullDownListView : ListView, Android.Widget.AbsListView.IOnScrollListener {

	private bool pulledDown;
		public delegate void Onlistviewpulleddown();
		public Onlistviewpulleddown mPulledDownListDelegate;

		public PullDownListView(Context context) : base(context){
			init();

	}
//IOnScrollListener l	
		public void setPulledDown(bool pulledDown){
			this.pulledDown = pulledDown;
		}
		public bool isPulledDown() {
			return pulledDown;
		}

	private void init() {
		//setOnScrollListener(this);
			SetOnScrollListener (this);
	}



	private float lastY;

		public void OnScroll (AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
		{
			setPulledDown (false);
		}


		public void OnScrollStateChanged (AbsListView view, ScrollState scrollState)
		{
			//throw new System.NotImplementedException ();
		}

	//	public override Dispatch
	

	public override bool DispatchTouchEvent(MotionEvent ev) {
			if (ev.Action == MotionEventActions.Down) {
				lastY = ev.RawY;
			} else if (ev.Action == MotionEventActions.Move) {
				float newY = ev.RawY;
				setPulledDown ((newY - lastY) > 0);
				PostDelayed (delegate {
					if (isPulledDown ()) {
						if(mPulledDownListDelegate!=null){
							mPulledDownListDelegate();
						setPulledDown (false);
						}
					}
				}, 400);
		
			
				lastY = newY;
			}
			else if (ev.Action == MotionEventActions.Up) {
			lastY = 0;
		}

		

		
			
		
		return base.DispatchTouchEvent(ev);
	}

	







}
}
