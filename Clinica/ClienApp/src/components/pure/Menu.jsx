import { Image, Offcanvas } from "react-bootstrap";
import { NavCollapse } from "./NavCollapse.jsx";
import { APP_NAME } from "../../config/constants.js";
import { loadImages } from "../../util/loadImages.js";

const userControl = [
  {
    name: "Crear Usuarios",
    icon: "plus",
    path: "/user/create",
  },
  {
    name: "Listar Usuarios",
    icon: "list-check",
    path: "/user/list",
  },
  {
    name: "Eliminar Usuarios",
    icon: "list-check",
    path: "/user/list",
  },
  {
    name: "Editar Usuarios",
    icon: "list-check",
    path: "/user/list",
  },
];
export const Menu = ({ show, onClose }) => {
  return (
    <Offcanvas
      show={show}
      onHide={onClose}
      scroll={true}
      backdrop={true}
      className="bg-black bg-gradient text-light"
    >
      <Offcanvas.Header closeButton closeVariant="white">
        <Image
          fluid
          rounded
          width={75}
          height={75}
          src={loadImages("/Clinica_Medica.png")}
        />
        <Offcanvas.Title className="fw-bold">{APP_NAME}</Offcanvas.Title>
      </Offcanvas.Header>
      <Offcanvas.Body>
        <NavCollapse
          title={"Mantenimiento de Usuarios"}
          icon={"users"}
          items={userControl}
        />
        <NavCollapse
          title={"Mantenimiento de Usuarios"}
          icon={"users"}
          items={userControl}
        />
        <NavCollapse
          title={"Mantenimiento de Usuarios"}
          icon={"users"}
          items={userControl}
        />
        <NavCollapse
          title={"Mantenimiento de Usuarios"}
          icon={"users"}
          items={userControl}
        />
      </Offcanvas.Body>
    </Offcanvas>
  );
};
