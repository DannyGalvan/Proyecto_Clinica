import { useContext, useState } from "react";
import { Link } from "react-router-dom";
import { Button, Col, Image } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Menu } from "../components/pure/Menu.jsx";
import { APP_NAME } from "../config/constants.js";
import { loadImages } from "../util/loadImages.js";
import { AuthContext } from "../context/AuthContext.jsx";

export const Header = () => {
  const { logout } = useContext(AuthContext);

  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <header>
      <nav className="container-fluid py-2 m-0 bg-primary fixed-top bg-gradient d-flex flex-row">
        <Link
          to="/"
          className="col-lg-3 col-9 d-flex justify-content-around align-items-center text-decoration-none"
        >
          <Image
            fluid
            rounded
            alt={"Clínica_Medica"}
            width={70}
            height={70}
            src={loadImages("/Clinica_Medica.png")}
          />
          <p className="text-light h3 pt-2 fw-bold">{APP_NAME}</p>
        </Link>
        <Col
          lg={9}
          xs={3}
          className="d-flex justify-content-end align-items-center"
        >
          <Button className="px-4 me-2" variant="danger" onClick={logout}>
            <FontAwesomeIcon icon={"arrow-right-from-bracket"} />
          </Button>
          <Button className="px-4" variant="light" onClick={handleShow}>
            <FontAwesomeIcon icon={!show ? "bars" : "close"} />
          </Button>
        </Col>
        <Menu show={show} onClose={handleClose} />
      </nav>
    </header>
  );
};
