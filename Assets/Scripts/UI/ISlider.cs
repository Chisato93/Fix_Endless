using TMPro;
using UnityEngine.UI;

public interface ISlider
{
    public Image imgage { get; }
    public void SetSlide(float amount);
}
// ----------------------------------------------
//              Oxygen Slider
// ----------------------------------------------
public class OxygenSlideController : ISlider
{
    private Image image;

    Image ISlider.imgage => image;

    public OxygenSlideController(Image image)
    {
        this.image = image;
    }
    public void SetSlide(float amount)
    {
        image.fillAmount = amount;
    }
}// ----------------------------------------------
//              Sound Slider
// ----------------------------------------------
public class SoundSlideController : ISlider
{
    private Image image;

    Image ISlider.imgage => image;

    public SoundSlideController(Image image)
    {
        this.image = image;
    }
    public void SetSlide(float amount)
    {
        image.fillAmount = amount;
    }
}