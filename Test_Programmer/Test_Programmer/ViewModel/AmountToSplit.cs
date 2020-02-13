using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Test_Programmer.ViewModel
{
    public class AmountToSplit:BaseOnPropertyChange
    {
		public AmountToSplit()
		{
			ResutlAmount = "$0.0";
		}

		private double _DigitAmount;

		public double DigitAmount
		{
			get { return _DigitAmount; }
			set { _DigitAmount = value;
				OnPropertyChanged();
			}
		}

		private string _ResutlAmount;

		public string ResutlAmount
		{
			get { return _ResutlAmount; }
			set { _ResutlAmount = value; OnPropertyChanged("ResutlAmount"); }
		}

		private double _DigitSplit;

		public double DigitSplit
		{
			get { return _DigitSplit; }
			set { _DigitSplit = value; OnPropertyChanged("DigitSplit"); }
		}

		private void MinusSplitAmount()
		{
			DigitSplit -= 1;
			var res = DigitAmount / DigitSplit;
			ResutlAmount = "$" + res;
		}

		public void SumSplitAmount()
		{
			DigitSplit += 1;
			var res = DigitAmount / DigitSplit;
			ResutlAmount = "$" + res;
		}

		public ICommand SumAmount
		{
			get
			{
				return new Command(() =>
				{
					SumSplitAmount();
				});
			}
		}
		public ICommand MinusAmount
		{
			get
			{
				return new Command(() =>
				{
					MinusSplitAmount();
				});
			}
		}
	}
	public class EventsBehaviors : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.Unfocused += Bindable_Unfocused;
			base.OnAttachedTo(bindable);
		}

		private void Bindable_Unfocused(object sender, FocusEventArgs e)
		{
			//ViewModelMethods methods = new ViewModelMethods();
			//methods.SumSplitAmount();
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.Unfocused -= Bindable_Unfocused;
			base.OnDetachingFrom(bindable);
		}
	}
}
