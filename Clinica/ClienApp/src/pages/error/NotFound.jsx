import { AnimatedLink } from "../../components/pure/AnimatedLink.jsx";

export const NotFound = ({ Number, Message }) => {
  return (
    <div className="page-wrap d-flex flex-row align-items-center">
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-md-12 text-center">
            <span className="display-1 d-block">{Number}</span>
            <div className="mb-4 lead">{Message}</div>
            <AnimatedLink to={"/"} className="btn btn-link">
              Regresar Al Inicio
            </AnimatedLink>
          </div>
        </div>
      </div>
    </div>
  );
};
