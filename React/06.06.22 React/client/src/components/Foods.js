import React from 'react'

function Foods() {
  return (
    <div>
        <div className="card" style={{width: '18rem'}}>
        <img src="https://www.burgerking.com.tr/cmsfiles/products/rodeo-whopper-menu.png?v=188" className="card-img-top" alt="..." />
        <div className="card-body">
          <h5 className="card-title">Rodeo Whopper</h5>
          <p className="card-text">Whopper® eti, büyük boy susamlı sandviç ekmeği, mayonez, doğranmış marul, soğan halkaları, nefis barbekü sosu ve 2 adet cheddar peynirinden oluşan Whopper® lezzeti. Enfes patates kızartması ve içeceğiyle birlikte Rodeo Whopper® Menü keyfini istediğin gibi yaşa!</p>
          <a href="#" className="btn btn-primary">Satın al</a>
        </div>
      </div>
    </div>
  )
}

export default Foods