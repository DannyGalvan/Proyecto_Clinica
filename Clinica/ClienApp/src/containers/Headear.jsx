import React, { useContext, useState, useRef } from "react";
import { Button, Col, Image } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Menu } from "../components/pure/Menu.jsx";
import { APP_NAME } from "../config/constants.js";
import { loadImages } from "../util/loadImages.js";
import { AuthContext } from "../context/AuthContext.jsx";
import { AnimatedLink } from "../components/pure/AnimatedLink.jsx";
import { useNavigate } from "react-router-dom";
import { CSSTransition, SwitchTransition } from "react-transition-group";

export const Header = () => {
  const { logout } = useContext(AuthContext);
  const navigate = useNavigate();
  const [show, setShow] = useState(false);
  const helloRef = React.useRef(null);
  const goodbyeRef = React.useRef(null);
  const nodeRef = show ? helloRef : goodbyeRef;
  const handleShow = () => setShow(!show);
  const handleClose = () => {
    logout();
    navigate("/Login");
  };

  return (
    <header>
      <nav className="container-fluid py-2 m-0 bg-primary fixed-top bg-gradient d-flex flex-row">
        <AnimatedLink
          to="/"
          className="col-lg-3 col-9 d-flex justify-content-around align-items-center text-decoration-none"
        >
          <Image
            fluid
            rounded
            alt={"Clínica_Medica"}
            width={70}
            height={70}
            src={loadImages("/clinicMedic.png")}
          />
          <p className="text-light h3 pt-2 fw-bold">{APP_NAME}</p>
        </AnimatedLink>
        <Col
          lg={9}
          xs={3}
          className="d-flex justify-content-end align-items-center"
        >
          <Button className="px-4 me-2" variant="danger" onClick={handleClose}>
            <FontAwesomeIcon icon={"arrow-right-from-bracket"} />
          </Button>
          <SwitchTransition>
            <CSSTransition
              key={show}
              nodeRef={nodeRef}
              addEndListener={(done) => {
                nodeRef.current.addEventListener("transitionend", done, false);
              }}
              classNames="rotate"
            >
              <Button className="px-4" variant="light" onClick={handleShow}>
                <FontAwesomeIcon
                  ref={nodeRef}
                  icon={!show ? "bars" : "close"}
                />
              </Button>
            </CSSTransition>
          </SwitchTransition>
        </Col>
        <Menu show={show} onClose={handleShow} />
      </nav>
    </header>
  );
};
