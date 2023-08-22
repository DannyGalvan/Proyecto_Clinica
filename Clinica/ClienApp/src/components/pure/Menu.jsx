import { Image, Offcanvas } from "react-bootstrap";
import { NavCollapse } from "./NavCollapse.jsx";
import { APP_NAME } from "../../config/constants.js";
import { loadImages } from "../../util/loadImages.js";
import { useContext } from "react";
import { AuthContext } from "../../context/AuthContext.jsx";

export const Menu = ({ show, onClose }) => {
  const { authState } = useContext(AuthContext);
  return (
    <Offcanvas
      show={show}
      onHide={onClose}
      scroll={true}
      backdrop={false}
      className="bg-black bg-gradient text-light"
    >
      <Offcanvas.Header closeButton closeVariant="white">
        <Image
          fluid
          rounded
          width={75}
          height={75}
          src={loadImages("/clinicMedic.png")}
        />
        <Offcanvas.Title className="fw-bold">{APP_NAME}</Offcanvas.Title>
      </Offcanvas.Header>
      <Offcanvas.Body>
        {authState.operations.map((o) => (
          <NavCollapse
            key={o.module.id}
            title={o.module.name}
            icon={o.module.image}
            items={o.operations}
          />
        ))}
      </Offcanvas.Body>
    </Offcanvas>
  );
};
