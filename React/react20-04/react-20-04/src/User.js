import React from 'react'

function User(props) {
  return (
    <div>
        <center>
        <h1>Username:{props.kullaniciAdi}</h1>
        <h1>Name:{props.isim}</h1>
        <h1>Surname:{props.soyİsim}</h1>
        <img src={props.foto}></img>
        </center>
        
    </div>
  )
}


export default User
