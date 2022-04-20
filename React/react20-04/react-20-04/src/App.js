import logo from './logo.svg';
import './App.css';
import User from './User';

function App() {
 
  return (
    <div onClick={()=>{
      console.log("div clicked");
    }}>
     <h1>Wissen Akademie</h1>
     <form onSubmit={e => {
       e.preventDefault();
       console.log("submit gerçekleşti.")
     } }>
       Name: <input onChange={e => {
        console.log('something wrote', e.target.value, e.target.name)}
       }  name="barbaros"/>
     </form>

    </div>
  );
}

export default App;
