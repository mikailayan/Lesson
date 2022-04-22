import axios from 'axios'
import React, { useEffect, useState } from 'react'

function CovidApi() {
    const [data, setData] = useState("")
    const [tarih, setTarih] = useState("")
    useEffect(() => {
        axios.get('https://raw.githubusercontent.com/ozanerturk/covid19-turkey-api/master/dataset/timeline.json')
            .then((res) => setData(res.data[tarih]))
            .catch((err) => console.log(err));
    }, [data, tarih]);
    return (
        <div>
            <div className='container'>
                <div className='row'>
                    <div className='col-md-8 mx-auto mt-4'>
                        <h2 className='text-center'>TÜRKİYE GÜNCEL COVİD-19 VERİLERİ</h2>
                        <input placeholder='GG/AA/YYYY' className='form-control' onChange={e => setTarih(e.target.value)}></input>
                        <table className='table text-danger'>
                            <thead>
                                <tr>
                                    <th scope='col'>#</th>
                                    <th scope='col'>Test Sayısı</th>
                                    <th scope='col'>Günlük Hasta Sasyısı</th>
                                    <th scope='col'>Toplam Hasta Sayısı</th>
                                    <th scope='col'>Vefat Sayısı</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr className={data===undefined?"bg-dark":"bg-success"}>
                                    <td scope='row'>1</td>
                                    <td>{data === undefined ? "Veri bekleniyor" : data.totalTests}</td>
                                    <td>{data === undefined ? "Veri bekleniyor" : data.patients}</td>
                                    <td>{data === undefined ? "Veri bekleniyor" : data.totalPatients}</td>
                                    <td>{data === undefined ? "Veri bekleniyor" : data.deaths}</td>

                                  
                                
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

        </div>

    )
}

export default CovidApi