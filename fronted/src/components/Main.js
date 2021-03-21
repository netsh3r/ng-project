import React from 'react'
import logo from '../MainView.png'
import MainViewTopLeft from '../MainViewTopLeft.png'
import MainViewBottomRight from '../MainViewBottomRight.png'
import xMainView from '../xMainView.png'
import triangleMainView from '../triangleMainView.png'
import elipseMainView from '../elipseMainView.png'
import smallElipsesMainView from '../smallElipsesMainView.png'


const style={
    Main:
    {
        background:'#2D2B2B',
        width:'61em',
        height:'37em',
        backgroundImage:`url(${logo})`,
        backgroundSize: '100% 100%',
        position:'absolute',
        zIndex:'10'
    }
}


function Main(){
    return(
        <div className="container">
            <div className="d-flex justify-content-center">
                {/* <div className="MainView" style={style.Main}>
                </div> */}
                <div style={{
                    width:'66em',height:'35em',
                    background: 'rgb(2,0,36)',
                    background: 'linear-gradient(150deg, rgba(33,32,32,1) 0%, rgba(31,30,30,1) 100%)',
                    position:'absolute',
                    zIndex:'10'
                }}>
                    <div style={{zIndex:'11', width:'100%',height:'100%'}}>
                        <img src={MainViewTopLeft}  style={{
                            width:'45%',
                        }}/>
                        <img src={MainViewBottomRight}  style={{
                            width:'50%',
                            position:'relative',
                            bottom:'-267px',
                            right:'-54px'
                        }}/>
                        <div>
                            <img src={elipseMainView}  style={{
                                width:'calc(35em/2.5)',
                                position:'absolute',
                                bottom:'61px',
                                left:'152px'
                            }}/>
                            
                            <img src={xMainView}  style={{
                                width:'9em',
                                position:'absolute',
                                bottom:'135px',
                                left:'344px'
                            }}/>
                            <img src={triangleMainView}  style={{
                                width:'10em',
                                position:'absolute',
                                bottom:'253px',
                                left:'253px'
                            }}/>
                            <img src={smallElipsesMainView}  style={{
                                width:'calc(35em/1.7)',
                                position:'absolute',
                                bottom:'20px',
                                left:'20px'
                            }}/>
                        </div>
                        <div style={{
                                zIndex:'12',
                                display: 'flex',
                                justifyContent: 'end',
                                top: '-235px',
                                position: 'relative',
                                left: '-15px',
                                right: '15px',
                                fontSize:'50pt',
                                fontWeight:'bold'
                            }}>
                            <div>
                                реализуй свою
                            </div>
                        </div>
                        <div style={{
                                zIndex:'12',
                                display: 'flex',
                                justifyContent: 'end',
                                top: '-300px',
                                position: 'relative',
                                left: '-15px',
                                right: '15px',
                                fontSize:'85pt',
                                fontWeight:'bold'
                            }}>
                            <div className="svetyash-chiysya">
                                мечту
                            </div>
                        </div>
                    </div>
                    
                </div>
                <div style={{background:'#1D9DFA',width:'calc(70em/2)',height:'calc(35em/2)',left:'-25px',
                top:'calc((35em/2) + 25px)',position:'relative',zIndex:'2'}}></div>
                <div style={{background:'#1D9DFA',width:'calc(61em/2)',height:'calc(35em/2)',right:'-25px',
                top:'-25px',position:'relative',zIndex:'1'}}></div>
            </div>

            
        </div>
    )
}

export default Main;