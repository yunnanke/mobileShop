import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useAuth } from "../app/AuthContext";
import type { DemoRole, LoginFormValues } from "../types/auth";

const loginSchema = z.object({
  login: z.string().min(2, "Введите логин"),
  password: z.string().min(4, "Введите пароль"),
  role: z.enum(["guest", "client", "consultant", "admin"])
});

export function LoginModal({
  isOpen,
  onClose
}: {
  isOpen: boolean;
  onClose: () => void;
}) {
  const { signIn } = useAuth();
  const {
    register,
    handleSubmit,
    formState: { errors }
  } = useForm<LoginFormValues>({
    resolver: zodResolver(loginSchema),
    defaultValues: {
      login: "",
      password: "",
      role: "client"
    }
  });

  if (!isOpen) {
    return null;
  }

  function onSubmit(values: LoginFormValues) {
    signIn(values);
    onClose();
  }

  return (
    <div className="modal-backdrop" role="presentation" onClick={onClose}>
      <div className="login-modal" role="dialog" aria-modal="true" onClick={(event) => event.stopPropagation()}>
        <div className="login-modal__header">
          <p>Демо-авторизация</p>
          <button type="button" className="ghost-button" onClick={onClose}>
            Закрыть
          </button>
        </div>

        <form className="login-form" onSubmit={handleSubmit(onSubmit)}>
          <label>
            <span>Логин</span>
            <input {...register("login")} placeholder="manager.demo" />
            {errors.login ? <small>{errors.login.message}</small> : null}
          </label>

          <label>
            <span>Пароль</span>
            <input type="password" {...register("password")} placeholder="••••••••" />
            {errors.password ? <small>{errors.password.message}</small> : null}
          </label>

          <fieldset className="role-grid">
            <legend>Роль для макета</legend>
            {(
              [
                ["guest", "Гость"],
                ["client", "Клиент"],
                ["consultant", "Сотрудник"],
                ["admin", "Администратор"]
              ] as [DemoRole, string][]
            ).map(([role, label]) => (
              <label key={role} className="role-option">
                <input type="radio" value={role} {...register("role")} />
                <span>{label}</span>
              </label>
            ))}
          </fieldset>

          <button type="submit" className="primary-button">
            Открыть интерфейс
          </button>
        </form>
      </div>
    </div>
  );
}
