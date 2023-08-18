import { useNavigate } from "react-router-dom";
import { transitionViewIfSupported } from "../../util/ViewTransition.js";

export const AnimatedLink = ({ className, to, children }) => {
  const navigate = useNavigate();

  return (
    <a
      href={to}
      className={className}
      onClick={(ev) => {
        ev.preventDefault();
        transitionViewIfSupported(() => {
          navigate(to);
        });
      }}
    >
      {children}
    </a>
  );
};
