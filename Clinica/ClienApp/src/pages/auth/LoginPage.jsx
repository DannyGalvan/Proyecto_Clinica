import { useContext } from "react";
import { Container, Row, Col, Image, Form } from "react-bootstrap";
import { Link } from "react-router-dom";
import { Login } from "../../api/Login.js";
import { useForm } from "../../hooks/useForm.jsx";
import { InputFormFloating } from "../../components/Input/InputFormFloating";
import { ButtonLoading } from "../../components/Buttons/ButtonLoading";
import { Response } from "../../components/Messages/Response";
import { AuthContext } from "../../context/AuthContext.jsx";
import { loadImages } from "../../util/loadImages.js";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const initialForm = {
  email: "",
  password: "",
};

const validationsForm = (form) => {
  let errors = {};
  const regexEmail =
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

  if (!form.email.trim()) {
    errors.email = "El 'correo' no puede ser vacio";
  } else if (!regexEmail.test(form.email)) {
    errors.email = "El 'correo' es invalido";
  }

  if (!form.password.trim()) {
    errors.password = "La 'contraseña' no puede ser vacia";
  }

  return errors;
};

const LoginPage = () => {
  const { signIn } = useContext(AuthContext);
  const send = async (form) => {
    const res = await Login(form);
    if (res.success != 0) {
      signIn(res.data);
    }
    return res;
  };

  const {
    form,
    errors,
    response,
    loading,
    handleBlur,
    handleChange,
    handleSubmit,
  } = useForm(initialForm, validationsForm, send);

  return (
    <Container className="d-flex align-items-center justify-content-center page-wrap">
      <Row className="justify-content-center align-items-center">
        <Col
          xs={8}
          md={6}
          lg={6}
          className="d-flex align-items-center mt-5 mt-md-0 intermittent"
        >
          <Image fluid alt="Logo" src={loadImages(`/Clinica_Medica.png`)} />
        </Col>
        <Col
          xs={11}
          md={6}
          lg={6}
          className="my-auto mx-auto mb-5 mt-5 mt-lg-0 login p-0"
        >
          <div className="bg-primary bg-gradient p-3 py-4">
            <h3 className="text-center fw-bold text-light">
              {" "}
              <FontAwesomeIcon icon={"lock"} /> INGRESA
            </h3>
          </div>
          <Form className="card p-5" onSubmit={handleSubmit}>
            <InputFormFloating
              label="Correo Electronico"
              name="email"
              error={errors.email}
              type="email"
              placeholder="nombre@ejemplo.com"
              value={form.correo}
              onBlur={handleBlur}
              onChange={handleChange}
            />
            <InputFormFloating
              label="Contraseña"
              name="password"
              error={errors.password}
              type="password"
              placeholder="****"
              value={form.password}
              onBlur={handleBlur}
              onChange={handleChange}
              autocomplete={"false"}
            />
            <div className="d-flex justify-content-between mx-4 my-4">
              <Form.Check
                type="checkbox"
                id={`default-checkbox`}
                label={`Mantener sesión abierta`}
              />
            </div>
            <div className="d-grid gap-2 mb-4">
              <ButtonLoading
                text="INICIAR SESIÓN"
                size="md"
                type="submit"
                variant="primary"
                loading={loading}
              />
            </div>
            <Link to={`/forgot_password/reset`} className="text-center mb-3">
              ¿Olvido su Contraseña?
            </Link>
            {response && (
              <Response code={response.success} message={response.message} />
            )}
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default LoginPage;
