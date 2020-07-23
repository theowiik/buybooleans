using Godot;

namespace buybooleans.Scripts
{
  public sealed class Main : Node2D
  {
    private Label _booleansLabel;
    private int _nbBooleans;

    private Main()
    {
      _nbBooleans = 0;
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
      UpdateBooleans();
    }

    #endregion

    #region Signals

    private void OnAddPressed()
    {
      _nbBooleans++;
      UpdateBooleans();
    }

    #endregion
  }
}