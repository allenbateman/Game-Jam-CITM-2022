using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Player player;

    [SerializeField]
    Sprite[] defaultBulletSprites;

    [SerializeField]
    Sprite[] fireBulletSprites;

    [SerializeField]
    Sprite[] iceBulletSprites;

    Animation[] bulletAnimations = new Animation[(int)bulletType.NONE];

    [SerializeField]
    Image bullet_sr;

    void Start()
    {
        player = FindObjectOfType<Player>();

        bulletAnimations[(int)bulletType.DEFAULT] = new Animation(defaultBulletSprites, player.getDefaultBulletCd() / defaultBulletSprites.Length, bullet_sr);
        bulletAnimations[(int)bulletType.FIRE] = new Animation(fireBulletSprites, player.getFireBulletCd() / fireBulletSprites.Length, bullet_sr);
        bulletAnimations[(int)bulletType.ICE] = new Animation(iceBulletSprites, player.getIceBulletCd() / iceBulletSprites.Length, bullet_sr);
    }

    void Update()
    {
        int bullet = (int)player.getCurrentBullet();
        Sprite mainSprite = null;

        float time = 0.0f;

        switch (player.getCurrentBullet())
        {
            case bulletType.DEFAULT:
                time = player.getDefaultBulletTimer();
                mainSprite = defaultBulletSprites[defaultBulletSprites.Length-1];
                break;
            case bulletType.FIRE:
                time = player.getFireBulletTimer();
                mainSprite = fireBulletSprites[fireBulletSprites.Length - 1];
                break;
            case bulletType.ICE:
                time = player.getIceBulletTimer();
                mainSprite = iceBulletSprites[iceBulletSprites.Length - 1];
                break;
        }

        if(time > 0.0f)
        {
            bulletAnimations[bullet].Update();
        }
        else
        {
            bulletAnimations[bullet].Reset();

            bullet_sr.sprite = mainSprite;
        }
    }
}
