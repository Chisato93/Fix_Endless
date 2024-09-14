public class BestDistanceClass
{
    private int bsetDistance;
    public int BestDistance { get { return bsetDistance; } set { bsetDistance = value; } }
    public void SetBestDistance(int newDistance)
    {
        if(newDistance > bsetDistance)
            bsetDistance = newDistance;
    }
}
