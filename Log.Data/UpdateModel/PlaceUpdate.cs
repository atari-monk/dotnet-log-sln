using ModelHelper;

namespace Log.Data;

public class PlaceUpdate 
    : ModelAUpdate
    , IUpdatable<Place>
{
    public void Update(Place model)
    {
        base.Update(model);
    }
}