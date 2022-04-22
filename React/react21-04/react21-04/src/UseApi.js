import React, { useEffect, useState } from 'react'
import axios from 'axios'



function UseApi() {
    const [users, setUsers] = useState([])
    const [singleUser, SetSingleUser] = useState([])

    useEffect(function () {
        axios
            .get("https://jsonplaceholder.typicode.com/users")
            .then((response) => setUsers(response.data))
            .then((error) => console.log(error))
    }, []);
    const onchangeHandler = (e) => {
        axios.get('https://jsonplaceholder.typicode.com/users/' + e.target.value)
            .then((response) => SetSingleUser(response.data)).then((error) => console.log(error))
    }
    return (
        <div>
            <select onChange={onchangeHandler} className="form-control w-25">
                <option value='0'>Kullanıcı Seçiniz</option>
                {users.map((user) => (
                    <option value={user.id} key={user.id}>{user.name}</option>
                ))}
            </select>
             <br />
            <hr />
            <table className='table table-striped table-hover'>
            <thead>
                <tr>
                    <td>ID</td>
                    <td>Name</td>
                    <td>Username</td>
                    <td>E-Mail</td>
                </tr>
                </thead>
               
                    <tbody>
                        <tr>
                            <td>{singleUser.id}</td>
                            <td>{singleUser.name}</td>
                            <td>{singleUser.username}</td>
                            <td>{singleUser.email}</td>
                        </tr>
                    </tbody>
               

            </table>
        </div>
    )
}

export default UseApi