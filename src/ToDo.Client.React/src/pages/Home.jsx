import React from 'react';
import { useState } from 'react'
//import reactLogo from '../assets/react.svg'
//import viteLogo from '../vite.svg'
import Typography from '@mui/material/Typography';


function Home() {
    const [count, setCount] = useState(0)
    return (
<>
<div>
  <a href="https://vitejs.dev" target="_blank">
    {/*<img src={viteLogo} className="logo" alt="Vite logo" />*/}
    <img src="/vite.svg" className="logo" alt="Vite logo" />
  </a>
  <a href="https://react.dev" target="_blank">
    {/*<img src={reactLogo} className="logo react" alt="React logo" />*/}
  </a>
</div>
<h1>Vite + React</h1>
<div className="card">
  <button onClick={() => setCount((count) => count + 1)}>
    count is {count}
  </button>
  <p>
    Edit <code>src/App.jsx</code> and save to test HMR
  </p>
  <Typography variant="h4" component="h1" gutterBottom>
    MUI!!!
  </Typography>
</div>
<p className="read-the-docs">
  Click on the Vite and React logos to learn more
</p>
</>
    )
}

export default Home;