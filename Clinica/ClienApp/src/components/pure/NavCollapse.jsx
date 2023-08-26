import React, { useState } from "react";
import { Button, Collapse } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { AnimatedLink } from "./AnimatedLink.jsx";
import { CSSTransition, SwitchTransition } from "react-transition-group";

export const NavCollapse = ({ items, title, icon }) => {
  const [open, setOpen] = useState(false);
  const helloRef = React.useRef(null);
  const goodbyeRef = React.useRef(null);
  const nodeRef = open ? helloRef : goodbyeRef;

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

        <SwitchTransition>
          <CSSTransition
            key={open}
            nodeRef={nodeRef}
            addEndListener={(done) => {
              nodeRef.current.addEventListener("transitionend", done, false);
            }}
            classNames="rotate"
          >
            <FontAwesomeIcon
              ref={nodeRef}
              icon={!open ? "angle-left" : "angle-down"}
            />
          </CSSTransition>
        </SwitchTransition>
      </span>
      <Collapse in={open}>
        <div id="example-collapse-text" className="ms-3 mt-1">
          {items.map(
            (item, key) =>
              item.isVisible && (
                <AnimatedLink className="nav-link p-2" key={key} to={item.path}>
                  <FontAwesomeIcon icon={item.icon} /> {item.name}
                </AnimatedLink>
              ),
          )}
        </div>
      </Collapse>
    </article>
  );
};
