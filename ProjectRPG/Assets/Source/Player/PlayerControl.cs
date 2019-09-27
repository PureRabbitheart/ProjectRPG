﻿/// <summary>
/// プレイヤーの基本的な処理
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float testPos = 0.0f;

    /// <summary>
    /// プレイヤーの移動処理の制御
    /// </summary>
    /// <param name="PlayerStatus">プレイヤーの情報</param>
    public void PlayerController( ref PlayerManager.PLAYER_STATUS PlayerStatus ) 
    {
        Move( ref PlayerStatus._transform , PlayerStatus.fSpeed);
        //jump(ref PlayerStatus.isGround , ref PlayerStatus._rigidbody);
    }
    
    /// <summary>
    /// 移動の処理
    /// </summary>
    /// <param name="_rigidbody">物理エンジン</param>
    private void Move( ref Transform _transform　, float Speed )
    {
        var vx =_transform.position.x;

        if(InputManager.GetAxisHorizontal() > 0.0f)
        {
            vx = _transform.position.x + Speed;
        }
        else if(InputManager.GetAxisHorizontal() < -0.0f)
        {
            vx = _transform.position.x + -Speed;
        }

        _transform.position = new Vector2( vx , _transform.position.y );
    }

    /// <summary>
    /// マ〇オジャンプの処理
    /// </summary>
    /// <param name="isGround">地面に接しているかフラグ</param>
    /// <param name="_rigidbody">物理エンジン</param>
    private void jump(ref bool isGround , ref Rigidbody2D _rigidbody) 
    {
        var speed = 10.0f;
        var xv = speed * Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(xv, Mathf.Max(-5.0f, _rigidbody.velocity.y));

        var jumpPower = 5.0f;
        if(isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpPower);
        }
        if(isGround == false && _rigidbody.velocity.y > 0.0f && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.gravityScale = 0.5f;
        }
        else 
        {
            _rigidbody.gravityScale = 1.0f;
        }
    }
}
