import React from 'react'
import Autorization from './Autorization'

function Header()
{
    return(
        <div>
            <nav className="navbar navbar-expand-sm navbar-toggleable-sm mb-3">
                <div className="container">
                    <a className="nvabar-brand">NG PROJECT</a>
                    <nav className="my-2 my-md-0 me-md-3">
                        <ul className="navbar-nav flex-grow-1">
                            <li className="nav-item">
                                <a className="nav-link">Проекты</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link">Участники</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link">О нас</a>
                            </li>
                            <li className="nav-item">
                                <Autorization/>
                            </li>
                        </ul>
                        
                    </nav>
                </div>
                
            </nav>
        </div>
    )
}

export default Header;