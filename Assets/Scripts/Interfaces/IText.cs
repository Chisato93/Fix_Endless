using TMPro;

public interface IText
{
    public TMP_Text TextComponent { get; }

    public void UpdateText(int amount);
}
// ----------------------------------------------
//              Gold Text
// ----------------------------------------------
public class GoldTextController : IText
{
    private TMP_Text goldText;

    TMP_Text IText.TextComponent => goldText;

    public GoldTextController(TMP_Text goldText)
    {
        this.goldText = goldText;
    }

    public void UpdateText(int amount)
    {
        goldText.text = amount.ToString();
    }

}

// ----------------------------------------------
//              Distance Text
// ----------------------------------------------
public class DistanceTextController : IText
{
    private TMP_Text distanceText;

    TMP_Text IText.TextComponent => distanceText;
    public DistanceTextController(TMP_Text distanceText)
    {
        this.distanceText = distanceText;
    }
    public void UpdateText(int amount)
    {
        distanceText.text = amount.ToString("#,##0") + " m";
    }
}