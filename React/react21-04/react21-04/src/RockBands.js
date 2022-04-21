import React from 'react'

function RockBands() {
    const rockbands = [
        {
            name: "Barbaros",
            id: "01",
            img: "https://picsum.photos/id/45/400/300"
        },
        {
            name: "Aslı",
            id: "02",
            img: "https://picsum.photos/id/55/400/300"
        },
        {
            name: "Mikail",
            id: "03",
            img: "https://picsum.photos/id/52/400/300"
        },
        {
            name: "Recep",
            id: "04",
            img: "https://picsum.photos/id/58/400/300"
        },
        {
            name:"enes",
            id:"05",
            img:"https://picsum.photos/id/28/400/300"
        },
        {
            name:"ouz",
            id:"06",
            img:"https://picsum.photos/id/61/400/300"
        }

    ]

    return (
        <div style={{backgroundImage:`url(${"https://images4.alphacoders.com/660/thumb-1920-660515.jpg"})`}}>
            <div className="row">
                {rockbands.map((x) =>

                    <div className="col-12 col-md-6 d-flex justify-content-center my-3 ">
                        <div className="card text-white bg-dark " style={{ width: '30rem' }}>
                            <img src={x.img} className="card-img-top" alt="..." />
                            <ul className="list-group list-group-flush">
                                <li className="list-group-item text-green bg-danger">ID: {x.id}</li>
                                <li className="list-group-item text-green bg-warning">isim: {x.name}</li>
                            </ul>
                        </div>

                    </div>
                )}
            </div>

        </div>
    )
}

export default RockBands