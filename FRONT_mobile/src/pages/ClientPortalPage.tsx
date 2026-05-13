import { SectionTitle } from "../components/SectionTitle";
import { clientContracts, clientProfile, clientRepairs, recentSales } from "../data/mockData";

export function ClientPortalPage() {
  return (
    <div className="page-stack">
      <section className="dashboard-hero">
        <SectionTitle
          eyebrow="Клиент"
          title={clientProfile.fullName}
          description="Макет личного кабинета: профиль, бонусная программа, ремонты, покупки и договоры."
        />
        <div className="summary-ribbon">
          <div>
            <span>Уровень</span>
            <strong>{clientProfile.level}</strong>
          </div>
          <div>
            <span>Баллы</span>
            <strong>{clientProfile.bonusPoints}</strong>
          </div>
          <div>
            <span>Регистрация</span>
            <strong>{clientProfile.registrationDate}</strong>
          </div>
        </div>
      </section>

      <section className="dashboard-grid">
        <article className="dashboard-card">
          <h3>Профиль</h3>
          <dl className="info-list">
            <div>
              <dt>Телефон</dt>
              <dd>{clientProfile.phone}</dd>
            </div>
            <div>
              <dt>Email</dt>
              <dd>{clientProfile.email}</dd>
            </div>
          </dl>
        </article>

        <article className="dashboard-card">
          <h3>Мои ремонты</h3>
          <div className="mini-table">
            {clientRepairs.map((repair) => (
              <div key={repair.id} className="mini-table__row">
                <div>
                  <strong>#{repair.id}</strong>
                  <span>{repair.issueType}</span>
                </div>
                <div>
                  <small>{repair.acceptedAt}</small>
                  <strong>{repair.status}</strong>
                </div>
              </div>
            ))}
          </div>
        </article>

        <article className="dashboard-card">
          <h3>Мои договоры</h3>
          <div className="mini-table">
            {clientContracts.map((contract) => (
              <div key={contract.id} className="mini-table__row">
                <div>
                  <strong>{contract.type}</strong>
                  <span>{contract.simNumber}</span>
                </div>
                <div>
                  <small>{contract.startedAt}</small>
                  <strong>{contract.expiresAt || "без срока"}</strong>
                </div>
              </div>
            ))}
          </div>
        </article>
      </section>

      <section className="paper-section">
        <SectionTitle
          eyebrow="Покупки"
          title="Последние продажи"
          description="Позже сюда пойдут реальные данные из клиентского sales endpoint."
        />

        <div className="showcase-grid">
          {recentSales.map((sale) => (
            <article key={sale.id} className="metric-card">
              <span>{sale.subtitle}</span>
              <h3>{sale.title}</h3>
              <p>{sale.amount}</p>
            </article>
          ))}
        </div>
      </section>
    </div>
  );
}
