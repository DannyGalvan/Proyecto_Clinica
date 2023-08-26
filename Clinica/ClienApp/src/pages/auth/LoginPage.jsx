import { useContext } from "react";
import { Container, Row, Col, Image, Form } from "react-bootstrap";
import { Login } from "../../api/Login.js";
import { useForm } from "../../hooks/useForm.jsx";
import { InputFormFloating } from "../../components/Input/InputFormFloating";
import { ButtonLoading } from "../../components/Buttons/ButtonLoading";
import { Response } from "../../components/Messages/Response";
import { AuthContext } from "../../context/AuthContext.jsx";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useMutation } from "@tanstack/react-query";
import { AnimatedLink } from "../../components/pure/AnimatedLink.jsx";
import Logo from "/clinicMedic.png";

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
  const { data, mutate, isLoading } = useMutation({
    mutationKey: ["addTodo"],
    mutationFn: (form) => Login(form),
    onSuccess: (data) => {
      data.success && signIn(data.data);
    },
  });

  const send = async (form) => {
    mutate(form);
  };

  const { form, errors, handleBlur, handleChange, handleSubmit } = useForm(
    initialForm,
    validationsForm,
    send,
  );

  return (
    <Container className="page-wrap">
      {data != null && <Response code={data.success} message={data.message} />}
      <Row className="justify-content-center align-items-center">
        <Col
          xs={8}
          md={10}
          lg={5}
          className="d-flex mt-5 mt-md-0 intermittent "
        >
          <Image fluid alt="Logo" className="w-100" src={Logo} />
        </Col>
        <Col
          xs={11}
          md={10}
          lg={5}
          className="my-auto mx-auto mb-5 mt-5 mt-lg-0 login p-0"
        >
          <div className="bg-primary bg-gradient p-3 py-4">
            <h3 className="text-center fw-bold text-light">
              {" "}
              <FontAwesomeIcon icon={"lock"} /> INGRESA
            </h3>
          </div>
          <Form className="card p-5 my-auto" onSubmit={handleSubmit}>
            <InputFormFloating
              label="Correo Electronico"
              name="email"
              error={errors.email}
              type="email"
              placeholder="nombre@ejemplo.com"
              value={form.email}
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
                loading={isLoading}
              />
            </div>
            <AnimatedLink
              to={`/forgot_password/reset`}
              className="text-center mb-3"
            >
              ¿Olvido su Contraseña?
            </AnimatedLink>
            <AnimatedLink to={`/createAccount`} className="text-center mb-3">
              ¿No Tienes Cuenta?
            </AnimatedLink>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default LoginPage;
