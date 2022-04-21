import React from 'react'

function Employee() {
    const employees = [
        {
            name:"Barbaros",
            id:"01"
        },
        {
            name:"Aslı",
            id:"02"
        },
        {
            name:"Mikail",
            id:"03"
        },
        {
            name:"Recep",
            id:"04"
        },

    ]
  return (
    <div>
        {employees.map((employee)=>(
        <div key={employee.id}>
            <h1>{`Name: ${employee.name} ID: ${employee.id}`}</h1>
        </div>
         ))}
    </div>
  )
}

export default Employee