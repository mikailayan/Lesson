import{ useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';

function App() {
const [employees, setEmployees] = useState([])
const [name,SetName]= useState("")
const [age,SetAge]= useState(0)
const [username,SetUserName]= useState("")

  useEffect(()=>{
    axios
    .get("http://localhost:3030/getEmployees")
    .then((response)=>setEmployees(response.data))
    .catch((err)=> console.log(err))
  },[employees])

  const createEmployee=()=>{
    axios
    .post("http://localhost:3030/createEmployee",{
      name:name,
      age:age,
      username:username
    }).then((res)=>{
      alert("Employee Created")
    })
    
  }

  return (
    <div className="App">
      {employees.map((employee)=>(

      <div>
        <h1>Name:{employee.name}</h1>
        <h1>Age:{employee.age}</h1>
        <h1>Username:{employee.username}</h1>
      </div>
      ))}
      <br/>
      <br/>
      <div>
        <center>
          <input placeholder='isim giriniz' type="text" onChange={(e)=> SetName (e.target.value)}/>
          <input placeholder='Yaş giriniz' type="number"onChange={(e)=> SetAge (e.target.value)}/>
          <input placeholder='Kullanıcı adı giriniz' type="text" onChange={(e)=> SetUserName (e.target.value)}/>
          <br/>
          <button onClick={createEmployee}>Create Emplotee</button>
        </center>
      </div>
    </div>
    
    
  );
}
export default App;
