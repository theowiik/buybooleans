using System;
using System.Collections.Generic;
using Godot;

namespace buybooleans.Scripts
{
  public sealed class Main : Node2D
  {
    private Label _booleansLabel;
    private int _nbBooleans;
    private Timer _tick;
    private readonly IList<ITicker> _tickers;
    private Label _tickLabel;

    private Main()
    {
      _nbBooleans = 0;
      _tickers = new List<ITicker>();
    }

    /// <summary>
    ///   Updates the amount of booleans.
    /// </summary>
    private void UpdateBooleans()
    {
      var prefix = _nbBooleans == 1 ? "boolean" : "booleans";
      _booleansLabel.Text = $"{_nbBooleans} {prefix}";
    }

    #region GodotOverrides

    public override void _Ready()
    {
      _booleansLabel = GetNode<Label>("VBoxContainer/Booleans");
      _tickLabel = GetNode<Label>("VBoxContainer/TickLabel");
      _tick = GetNode<Timer>("VBoxContainer/TickLabel/Tick");

      UpdateBooleans();
    }

    public override void _Process(float delta)
    {
      _tickLabel.Text = $"{Math.Round(_tick.TimeLeft, 2)}";
      UpdateBooleans();
    }

    #endregion

    #region Signals

    private void OnTickTimeout()
    {
      foreach (var tick in _tickers)
        _nbBooleans += tick.Get();
    }

    private void OnAddPressed()
    {
      _nbBooleans++;
    }

    private void OnAutoPressed()
    {
      if (_nbBooleans < 10) return;
      _nbBooleans -= 10;
      _tickers.Add(new Auto());
    }

    #endregion
  }
}