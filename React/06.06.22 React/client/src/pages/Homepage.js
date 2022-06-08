import React from 'react'
import Foods from '../components/Foods'

function Homepage() {
  return (
    <div>
        <div className='row'>
        {food.map((food)=>(
            <div className='col-md-4'>
                 <Foods food = {food}/>
            </div>
        ))}
        </div>
    </div>
  )
}

export default Homepage