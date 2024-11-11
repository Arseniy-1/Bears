public class Turning
{
    private readonly Character _character;
    private TargetScaner _scanner;
    
    public Turning(Character character)
    {
        _character = character;
    }

    public void CorrectFlip(bool flip)
    {
        if (_character.Scaner.HasTarget)
        {
            if (_character.Scaner.ClosestTarget.Position.x > _character.transform.position.x)
                _character.spriteWeapon.flipY = false;
            else
                _character.spriteWeapon.flipY = true;
        }
        else
        {
            if (flip)
                _character.spriteCharacter.flipX = !flip;
            else
                _character.spriteCharacter.flipX = flip;
        }
    }
}
