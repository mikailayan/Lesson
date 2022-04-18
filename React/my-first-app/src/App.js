import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

function App() {
  const[count, setCount] = useState(0)
  return (
    <div className="App">
            <div className="card" style={{width: '18rem'}}>
        <img src="https://picsum.photos/id/28/200/200" className="card-img-top" alt="..." />
        <div className="card-body">
          <h5 className="card-title">Card title</h5>
          <p className="card-text">{count}</p>
          <a href="#" className="btn btn-primary" onClick={()=> setCount(count+1)}>arttır</a>
          <a href="#" className="btn btn-primary" onClick={()=> setCount(count-1)}>azalt</a>
          <a href="#" className="btn btn-primary" onClick={()=> setCount(0)}>reset</a>


        </div>
      </div>
    </div>
  );
}

export default App;


