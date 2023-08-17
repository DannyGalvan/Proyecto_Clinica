import { useState } from "react";
import { Collapse } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";

export const NavCollapse = ({ items, title, icon }) => {
  const [open, setOpen] = useState(false);

  return (
    <article className="p-2 card my-1">
      <span
        onClick={() => setOpen(!open)}
        aria-controls="example-collapse-text"
        aria-expanded={open}
        className="nav-link d-flex justify-content-between"
      >
        <span className="fw-bold">
          <FontAwesomeIcon icon={icon} /> {title}
        </span>
        <FontAwesomeIcon icon={!open ? "angle-left" : "angle-down"} />
      </span>
      <Collapse in={open}>
        <div id="example-collapse-text" className="ms-3 mt-1">
          {items.map((item, key) => (
            <Link className="nav-link p-2" key={key} to={item.path}>
              <FontAwesomeIcon icon={item.icon} /> {item.name}
            </Link>
          ))}
        </div>
      </Collapse>
    </article>
  );
};
