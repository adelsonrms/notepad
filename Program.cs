// See https://aka.ms/new-console-template for more information
using app_blazor.Data.Entidades;

using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Text.Json;

using app_blazor.Data.Entidades;
using app_blazor.Data.ViewModels;
using app_blazor.Servicos;

using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

var builder = Host.CreateDefaultBuilder(args)
.ConfigureServices((hostContext, services) =>
{
    services.AddLogging();
    services.AddSingleton(hostContext.HostingEnvironment);
    services.AddScoped<IPdfService, PdfService>();
    services.AddScoped<TestDataService>();
})
.Build();

var logger = builder.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Iniciando aplicação...");

IPdfService PdfService = builder.Services.GetRequiredService<IPdfService>();
var workPermits = await builder.Services.GetRequiredService<TestDataService>().GerarDadosDeTeste();

var workPermit = workPermits.First();
string caminhoArquivo = await PdfService.PreencherPdf1Async(workPermit, modoPreview: true, @"F:\Cloud\OneDrive\Projetos\tecnun\Cayman\app-blazor\AppJS\pdf\pg2.pdf");
logger.LogInformation($"PDF gerado com sucesso em: {caminhoArquivo}");

namespace app_blazor.Data.Entidades
{
    /// <summary>
    /// Modelo principal para representar uma solicitação de permissão de trabalho temporário.
    /// </summary>
    public class WorkPermit
    {
        [Key]
        public string Id { get; set; }
        public string Status { get; set; } = "Draft";
        public int PaginaAtual { get; set; } = 1;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public bool Completo { get; set; } = false;

        public WorkPermit()
        {
            Page1_Dependents = new List<Dependente>();
            Page2_CriminalOffenses = new List<Ofensa>();
            Page2_AdministrativeFines = new List<MultaAdministrativa>();
            Page2_ProfessionalSanctions = new List<SancaoProfissional>();
        }

        #region Página 1
        // Informações Pessoais
        [Display(Name = "Surname")]
        public string? Page1_Surname { get; set; }

        [Display(Name = "Maiden Name")]
        public string? Page1_MaidenName { get; set; }

        [Display(Name = "Given Names")]
        public string? Page1_GivenNames { get; set; }

        [Display(Name = "Nationality")]
        public string? Page1_Nationality { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? Page1_DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string? Page1_Gender { get; set; }

        // Passport Information
        [Display(Name = "Passport Number")]
        public string? Page1_PassportNumber { get; set; }

        [Display(Name = "Date of Issue")]
        [DataType(DataType.Date)]
        public DateTime? Page1_PassportDateIssue { get; set; }

        [Display(Name = "Place of Issue")]
        public string? Page1_PassportPlaceIssue { get; set; }

        [Display(Name = "Date of Expiry")]
        [DataType(DataType.Date)]
        public DateTime? Page1_PassportDateExpiry { get; set; }

        // Other Names
        [Display(Name = "Known by other names")]
        public bool Page1_HasOtherNames { get; set; }

        [Display(Name = "Other Names")]
        public string? Page1_OtherNames { get; set; }

        // Physical Address
        [Display(Name = "House Number")]
        public string? Page1_HouseNumber { get; set; }

        [Display(Name = "Street Name")]
        public string? Page1_StreetName { get; set; }

        [Display(Name = "District")]
        public string? Page1_District { get; set; }

        [Display(Name = "PO Box")]
        public string? Page1_POBox { get; set; }

        [Display(Name = "Telephone")]
        public string? Page1_Telephone { get; set; }

        [Display(Name = "Has Email")]
        public bool Page1_HasEmail { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Page1_Email { get; set; }

        // Marital Status
        [Display(Name = "Marital Status")]
        public string? Page1_MaritalStatus { get; set; }

        [Display(Name = "Spouse Information")]
        public string? Page1_SpouseInfo { get; set; }

        // Job Information
        [Display(Name = "Position Applied For")]
        public string? Page1_PositionAppliedFor { get; set; }

        [Display(Name = "Relevant Experience")]
        public string? Page1_RelevantExperience { get; set; }

        [Display(Name = "Years of Experience")]
        public int? Page1_YearsExperience { get; set; }

        [Display(Name = "Has Pending Appeal")]
        public bool Page1_HasPendingAppeal { get; set; }

        [Display(Name = "Appeal Details")]
        public string? Page1_AppealDetails { get; set; }

        // Dependents
        public virtual ICollection<Dependente> Page1_Dependents { get; set; } = new List<Dependente>();
        #endregion

        #region Página 2
        // Criminal Record
        [Display(Name = "Has Criminal Record")]
        public bool Page2_HasCriminalRecord { get; set; }
        public virtual ICollection<Ofensa> Page2_CriminalOffenses { get; set; } = new List<Ofensa>();
        public virtual ICollection<Ofensa> Page2_DependantsCriminalOffenses { get; set; } = new List<Ofensa>();

        // Deportation
        [Display(Name = "Deported from Cayman")]
        public bool Page2_DeportedFromCayman { get; set; }
        public string? Page2_CaymanDeportationDetails { get; set; }

        [Display(Name = "Deported from Other Country")]
        public bool Page2_DeportedFromOtherCountry { get; set; }
        public string? Page2_OtherCountryDeportationDetails { get; set; }

        // Administrative Fines
        [Display(Name = "Has Administrative Fines")]
        public bool Page2_HasAdministrativeFines { get; set; }
        public virtual ICollection<MultaAdministrativa> Page2_AdministrativeFines { get; set; } = new List<MultaAdministrativa>();

        // Professional Sanctions
        [Display(Name = "Has Professional Sanctions")]
        public bool Page2_HasProfessionalSanctions { get; set; }
        public virtual ICollection<SancaoProfissional> Page2_ProfessionalSanctions { get; set; } = new List<SancaoProfissional>();

        // Questão 11
        [Display(Name = "Named as Dependant")]
        public bool Page2_WasNamedAsDependant { get; set; }
        public string? Page2_PermitHolderName { get; set; }

        // Questão 12
        [Display(Name = "Left Cayman Islands")]
        public bool Page2_LeftCaymanIslands { get; set; }
        public string? Page2_AbsenceDetails { get; set; }

        // Dependants Criminal Record
        [Display(Name = "Dependants Criminal Record")]
        public bool Page2_DependantsCriminalRecord { get; set; }

        // Questão 14
        public virtual ICollection<ResidenciaAnterior> Page2_PreviousResidences { get; set; } = new List<ResidenciaAnterior>();

        // Novas propriedades adicionadas para a Página 2
        public bool? Page2_HasDependants { get; set; }
        public bool? Page2_HasOtherNationality { get; set; }
        public string? Page2_OtherNationalityDetails { get; set; }
        public bool? Page2_HasCriminalOffence { get; set; }
        public string? Page2_CriminalOffenceDetails { get; set; }
        public bool? Page2_HasDeportation { get; set; }
        public string? Page2_DeportationDetails { get; set; }
        #endregion

        #region Página 3
        // Questão 15 - Conexões com Ilhas Cayman
        [Display(Name = "Caymanian Connections")]
        public bool? Page3_HasCaymanianConnections { get; set; }

        [Display(Name = "Caymanian Connection Details")]
        public string? Page3_CaymanianConnectionDetails { get; set; }

        // Tabela de conexões com Cayman (Nome, Relacionamento, Endereço)
        public virtual ICollection<CaymanConnection> Page3_CaymanConnections { get; set; } = new List<CaymanConnection>();

        // Questão 16 - Idioma Inglês
        [Display(Name = "Is English Native Language")]
        public bool? Page3_IsEnglishNativeLanguage { get; set; }

        [Display(Name = "Native Language")]
        public string? Page3_NativeLanguage { get; set; }

        [Display(Name = "Speaks English")]
        public bool? Page3_SpeaksEnglish { get; set; }

        [Display(Name = "Reads English")]
        public bool? Page3_ReadsEnglish { get; set; }

        [Display(Name = "Writes English")]
        public bool? Page3_WritesEnglish { get; set; }

        [Display(Name = "Currently On Island")]
        public bool? Page3_CurrentlyOnIsland { get; set; }

        // Testes de Inglês
        [Display(Name = "IELTS Tested")]
        public bool? Page3_IELTSTested { get; set; }

        [Display(Name = "IELTS Score")]
        public string? Page3_IELTSScore { get; set; }

        [Display(Name = "IELTS Report Number")]
        public string? Page3_IELTSReportNumber { get; set; }

        [Display(Name = "IELTS Exam Date")]
        [DataType(DataType.Date)]
        public DateTime? Page3_IELTSExamDate { get; set; }

        // TOEIC
        [Display(Name = "TOEIC Tested")]
        public bool? Page3_TOEICTested { get; set; }

        [Display(Name = "TOEIC Score")]
        public string? Page3_TOEICScore { get; set; }

        [Display(Name = "TOEIC Report Number")]
        public string? Page3_TOEICReportNumber { get; set; }

        [Display(Name = "TOEIC Exam Date")]
        [DataType(DataType.Date)]
        public DateTime? Page3_TOEICExamDate { get; set; }

        // Questão 17 - Saúde
        [Display(Name = "Good Physical and Mental Health")]
        public bool? Page3_GoodPhysicalMentalHealth { get; set; }

        [Display(Name = "Health Details")]
        public string? Page3_HealthDetails { get; set; }

        [Display(Name = "Dependants Good Health")]
        public bool? Page3_DependantsGoodHealth { get; set; }

        [Display(Name = "Dependants Health Details")]
        public string? Page3_DependantsHealthDetails { get; set; }

        [Display(Name = "Tested Positive for HIV or STD")]
        public bool? Page3_TestedPositiveSTD { get; set; }

        [Display(Name = "STD Test Details")]
        public string? Page3_STDTestDetails { get; set; }

        [Display(Name = "Accept Terms and Conditions")]
        public bool Page3_AcceptTerms { get; set; } = false;

        [Display(Name = "Signature Date")]
        [DataType(DataType.Date)]
        public DateTime? Page3_SignatureDate { get; set; }
        #endregion

        #region Página 4 - Empregador
        // Tipo de empregador
        [Display(Name = "Is Company")]
        public bool? Page4_IsCompany { get; set; }

        // 1.A - Se for uma empresa
        [Display(Name = "Company Name")]
        public string? Page4_CompanyName { get; set; }

        [Display(Name = "Nature of Business")]
        public string? Page4_NatureOfBusiness { get; set; }

        [Display(Name = "Company PO Box")]
        public string? Page4_CompanyPOBox { get; set; }

        [Display(Name = "Company Physical Address")]
        public string? Page4_CompanyPhysicalAddress { get; set; }

        [Display(Name = "Company Email")]
        public string? Page4_CompanyEmail { get; set; }

        [Display(Name = "Company Telephone")]
        public string? Page4_CompanyTelephone { get; set; }

        [Display(Name = "Business License Law")]
        public string? Page4_BusinessLicenseLaw { get; set; }

        [Display(Name = "License Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime? Page4_LicenseExpiryDate { get; set; }

        [Display(Name = "License Number")]
        public string? Page4_LicenseNumber { get; set; }

        [Display(Name = "Employee Is Shareholder")]
        public bool? Page4_EmployeeIsShareholder { get; set; }

        [Display(Name = "Shareholder Remuneration Yes/No")]
        public string? Page4_ShareholderRemunerationYesNo { get; set; }

        [Display(Name = "Shareholder Remuneration Details")]
        public string? Page4_ShareholderRemunerationDetails { get; set; }

        // 1.B - Se for um empregador pessoal
        [Display(Name = "Personal Employer Name")]
        public string? Page4_PersonalEmployerName { get; set; }

        [Display(Name = "Personal Employer Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? Page4_PersonalEmployerDateOfBirth { get; set; }

        [Display(Name = "Personal Employer PO Box")]
        public string? Page4_PersonalEmployerPOBox { get; set; }

        [Display(Name = "Personal Employer Telephone")]
        public string? Page4_PersonalEmployerTelephone { get; set; }

        [Display(Name = "Personal Employer Email")]
        public string? Page4_PersonalEmployerEmail { get; set; }

        [Display(Name = "Personal Employer Occupation")]
        public string? Page4_PersonalEmployerOccupation { get; set; }

        [Display(Name = "Personal Employer's Employer Name")]
        public string? Page4_PersonalEmployerEmployerName { get; set; }

        [Display(Name = "Personal Employer's Employer PO Box")]
        public string? Page4_PersonalEmployerEmployerPOBox { get; set; }

        [Display(Name = "Personal Employer's Employer Telephone")]
        public string? Page4_PersonalEmployerEmployerTelephone { get; set; }

        // 2. Permit Sharing
        [Display(Name = "Is Permit Shared")]
        public bool? Page4_IsPermitShared { get; set; }

        [Display(Name = "Additional Employer Name")]
        public string? Page4_AdditionalEmployerName { get; set; }

        [Display(Name = "Additional Employer Phone")]
        public string? Page4_AdditionalEmployerPhone { get; set; }

        [Display(Name = "Additional Employer Email")]
        public string? Page4_AdditionalEmployerEmail { get; set; }

        [Display(Name = "Additional Employer Is Person")]
        public bool? Page4_AdditionalEmployerIsPerson { get; set; }

        [Display(Name = "Additional Employer Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? Page4_AdditionalEmployerDateOfBirth { get; set; }

        [Display(Name = "Position with Additional Employer")]
        public string? Page4_PositionWithAdditionalEmployer { get; set; }

        [Display(Name = "Salary Currency Type")]
        public string? Page4_SalaryCurrencyType { get; set; } // CI$ ou US$

        [Display(Name = "Salary Amount")]
        public decimal? Page4_SalaryAmount { get; set; }

        [Display(Name = "Salary Period")]
        public string? Page4_SalaryPeriod { get; set; } // hour, day, week, month

        [Display(Name = "Hours with Additional Employer")]
        public int? Page4_HoursWithAdditionalEmployer { get; set; }

        // 3. Family Member
        [Display(Name = "Is Family Member")]
        public bool? Page4_IsFamilyMember { get; set; }

        [Display(Name = "Family Relationship")]
        public string? Page4_FamilyRelationship { get; set; }

        // 4. Occupation Description
        [Display(Name = "Occupation Description")]
        public string? Page4_OccupationDescription { get; set; }

        // 5. Required Skills
        [Display(Name = "Required Skills")]
        public string? Page4_RequiredSkills { get; set; }

        // 6. Employment Info
        [Display(Name = "Current Employees Count")]
        public int? Page4_CurrentEmployeesCount { get; set; }

        [Display(Name = "Caymanian Employees Count")]
        public int? Page4_CaymanianEmployeesCount { get; set; }

        [Display(Name = "Permanent Residents Count")]
        public int? Page4_PermanentResidentsCount { get; set; }

        // 7. JobsCayman Portal
        [Display(Name = "Registered on JobsCayman")]
        public bool? Page4_RegisteredOnJobsCayman { get; set; }

        [Display(Name = "JobsCayman Job ID")]
        public string? Page4_JobsCaymanJobID { get; set; }
        #endregion

        #region Página 5 - Empregador
        [Display(Name = "Job Advertised")]
        public bool? Page5_JobAdvertised { get; set; }

        [Display(Name = "Caymanian Applied")]
        public bool? Page5_CaymanianApplied { get; set; }

        [Display(Name = "Why None Hired")]
        public string? Page5_WhyNoneHired { get; set; }

        [Display(Name = "Permit Duration")]
        public string? Page5_PermitDuration { get; set; }

        [Display(Name = "Permit Start Date")]
        [DataType(DataType.Date)]
        public DateTime? Page5_PermitStartDate { get; set; }

        [Display(Name = "Coincide With Spouse")]
        public bool? Page5_CoincideWithSpouse { get; set; }

        [Display(Name = "Salary Currency Type")]
        public string? Page5_SalaryCurrencyType { get; set; }

        [Display(Name = "Salary Amount")]
        public decimal? Page5_SalaryAmount { get; set; }

        [Display(Name = "Salary Period")]
        public string? Page5_SalaryPeriod { get; set; }

        [Display(Name = "Weekly Hours")]
        public int? Page5_WeeklyHours { get; set; }

        [Display(Name = "Other Benefits")]
        public string? Page5_OtherBenefits { get; set; }

        [Display(Name = "Lives With Employer")]
        public bool? Page5_LivesWithEmployer { get; set; }

        [Display(Name = "Has Gratuities Scheme")]
        public bool? Page5_HasGratuitiesScheme { get; set; }

        [Display(Name = "Non-English Speaking Country")]
        public bool? Page5_NonEnglishSpeakingCountry { get; set; }

        [Display(Name = "Aware Of English Test")]
        public bool? Page5_AwareOfEnglishTest { get; set; }

        [Display(Name = "Satisfied With English")]
        public bool? Page5_SatisfiedWithEnglish { get; set; }

        [Display(Name = "English Steps Taken")]
        public string? Page5_EnglishStepsTaken { get; set; }

        [Display(Name = "Employer Signature Date")]
        [DataType(DataType.Date)]
        public DateTime? Page5_EmployerSignatureDate { get; set; }

        [Display(Name = "Additional Signature Date")]
        [DataType(DataType.Date)]
        public DateTime? Page5_AdditionalSignatureDate { get; set; }
        #endregion

        #region Página 6 - Pension Plan e Health Insurance
        // PENSION PLAN
        [Display(Name = "Has Valid Pension Plan")]
        public bool? Page6_HasValidPensionPlan { get; set; }

        [Display(Name = "Pension Plan No Reason")]
        public string? Page6_PensionPlanNoReason { get; set; }

        [Display(Name = "Pension Company Name")]
        public string? Page6_PensionCompanyName { get; set; }

        [Display(Name = "Pension Company Phone")]
        public string? Page6_PensionCompanyPhone { get; set; }

        [Display(Name = "Pension Company Email")]
        public string? Page6_PensionCompanyEmail { get; set; }

        [Display(Name = "Employee Pension Number")]
        public string? Page6_EmployeePensionNo { get; set; }

        [Display(Name = "Pension Registration Number")]
        public string? Page6_PensionRegistrationNo { get; set; }

        [Display(Name = "Pension Plan Paid Up To Date")]
        public bool? Page6_PensionPlanPaidUpToDate { get; set; }

        [Display(Name = "Pension Plan Not Paid Reason")]
        public string? Page6_PensionPlanNotPaidReason { get; set; }

        // HEALTH INSURANCE
        [Display(Name = "Has Valid Health Insurance")]
        public bool? Page6_HasValidHealthInsurance { get; set; }

        [Display(Name = "Health Insurance No Reason")]
        public string? Page6_HealthInsuranceNoReason { get; set; }

        [Display(Name = "Health Insurance Company Name")]
        public string? Page6_HealthInsuranceCompanyName { get; set; }

        [Display(Name = "Health Insurance Company Phone")]
        public string? Page6_HealthInsuranceCompanyPhone { get; set; }

        [Display(Name = "Health Insurance Company Email")]
        public string? Page6_HealthInsuranceCompanyEmail { get; set; }

        [Display(Name = "Employee Health Membership Number")]
        public string? Page6_EmployeeHealthMembershipNo { get; set; }

        [Display(Name = "Health Insurance Policy Number")]
        public string? Page6_HealthInsurancePolicyNo { get; set; }

        [Display(Name = "Health Insurance Paid Up To Date")]
        public bool? Page6_HealthInsurancePaidUpToDate { get; set; }

        [Display(Name = "Health Insurance Not Paid Reason")]
        public string? Page6_HealthInsuranceNotPaidReason { get; set; }

        // DECLARATIONS
        [Display(Name = "Employer Name")]
        public string? Page6_EmployerName { get; set; }

        [Display(Name = "Employer Print Name")]
        public string? Page6_EmployerPrintName { get; set; }

        [Display(Name = "Employer Signature Date")]
        public DateTime? Page6_EmployerSignatureDate { get; set; }

        [Display(Name = "Employee Name")]
        public string? Page6_EmployeeName { get; set; }

        [Display(Name = "Employee Signature Date")]
        public DateTime? Page6_EmployeeSignatureDate { get; set; }
        #endregion

        // Dados Adicionais em JSON
        [Column(TypeName = "longtext")]
        public string? DadosAdicionais { get; set; }

        /// <summary>
        /// Método para converter o modelo para formato JSON para armazenamento local
        /// </summary>
        public string ToJsonString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Método para criar uma instância a partir de uma string JSON
        /// </summary>
        public static WorkPermit FromJsonString(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<WorkPermit>(json) ?? new WorkPermit();
        }

        /// <summary>
        /// Converte a entidade WorkPermit para sua respectiva ViewModel usando Reflection
        /// </summary>
        public WorkPermitViewModel GetViewModel()
        {
            var viewModel = new WorkPermitViewModel
            {
                Id = Id,
                Status = Status,
                PaginaAtual = PaginaAtual,
                DataCriacao = DataCriacao,
                DataAtualizacao = DataAtualizacao,
                Completo = Completo
            };

            // Mapeia as propriedades principais
            MapProperties(this, viewModel);

            // Mapeia as coleções
            MapCollections(viewModel);

            return viewModel;
        }

        private void MapProperties(WorkPermit source, WorkPermitViewModel target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();

            // Obtém todas as propriedades da entidade que começam com "Page"
            var pageProperties = sourceType.GetProperties()
                .Where(p => p.Name.StartsWith("Page") && p.Name.Contains("_"));

            foreach (var sourceProp in pageProperties)
            {
                // Extrai o número da página e o nome da propriedade
                var parts = sourceProp.Name.Split('_');
                if (parts.Length != 2) continue;

                var pageNumber = parts[0];
                var propertyName = parts[1];

                // Obtém a propriedade da página correspondente na ViewModel
                var pageProperty = targetType.GetProperty(pageNumber);
                if (pageProperty == null) continue;

                // Obtém a instância da página
                var pageInstance = pageProperty.GetValue(target);
                if (pageInstance == null) continue;

                // Obtém a propriedade na página da ViewModel
                var targetProp = pageInstance.GetType().GetProperty(propertyName);
                if (targetProp == null) continue;

                // Copia o valor
                var value = sourceProp.GetValue(source);
                targetProp.SetValue(pageInstance, value);
            }
        }

        private void MapCollections(WorkPermitViewModel viewModel)
        {
            // Mapeia as coleções usando o método MapCollection
            MapCollection(Page1_Dependents, viewModel.Page1.Dependents, d => new DependenteViewModel
            {
                Nome = d.Nome,
                DataNascimento = d.DataNascimento,
                Nacionalidade = d.Nacionalidade,
                Relacao = d.Relacao,
                PaisResidencia = d.PaisResidencia,
                AdicionarAoVisto = d.AdicionarAoVisto
            });

            MapCollection(Page2_CriminalOffenses, viewModel.Page2.CriminalOffenses, o => new OfensaViewModel
            {
                Natureza = o.Natureza,
                Data = o.Data,
                Local = o.Local,
                Detalhes = o.Detalhes
            });

            MapCollection(Page2_DependantsCriminalOffenses, viewModel.Page2.DependantsCriminalOffenses, o => new OfensaViewModel
            {
                Natureza = o.Natureza,
                Data = o.Data,
                Local = o.Local,
                Detalhes = o.Detalhes
            });

            MapCollection(Page2_AdministrativeFines, viewModel.Page2.AdministrativeFines, m => new MultaAdministrativaViewModel
            {
                Natureza = m.Natureza,
                Data = m.Data,
                Local = m.Local,
                Valor = m.Valor
            });

            MapCollection(Page2_ProfessionalSanctions, viewModel.Page2.ProfessionalSanctions, s => new SancaoProfissionalViewModel
            {
                Natureza = s.Natureza,
                Data = s.Data,
                Local = s.Local,
                Detalhes = s.Detalhes
            });

            MapCollection(Page2_PreviousResidences, viewModel.Page2.PreviousResidences, r => new ResidenciaAnteriorViewModel
            {
                Pais = r.Pais,
                DataInicio = r.DataInicio,
                DataFim = r.DataFim,
                Endereco = r.Endereco
            });

            MapCollection(Page3_CaymanConnections, viewModel.Page3.CaymanConnections, c => new CaymanConnectionViewModel
            {
                Name = c.Name,
                Relationship = c.Relationship,
                Address = c.Address
            });
        }

        private void MapCollection<TEntity, TViewModel>(ICollection<TEntity> source, ICollection<TViewModel> target, Func<TEntity, TViewModel> mapper)
        {
            target.Clear();
            foreach (var item in source)
            {
                target.Add(mapper(item));
            }
        }

        public virtual ICollection<MultaAdministrativa> MultasAdministrativas { get; set; } = new List<MultaAdministrativa>();
        public virtual ICollection<SancaoProfissional> SancoesProfissionais { get; set; } = new List<SancaoProfissional>();
        public virtual ICollection<ResidenciaAnterior> ResidenciasAnteriores { get; set; } = new List<ResidenciaAnterior>();
        public virtual ICollection<Dependente> Dependentes { get; set; } = new List<Dependente>();
        public virtual ICollection<CaymanConnection> ConexoesCayman { get; set; } = new List<CaymanConnection>();
    }

    public class MultaAdministrativa
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Natureza { get; set; }
        public DateTime? Data { get; set; }
        public string? Local { get; set; }
        public decimal? Valor { get; set; }

        [ForeignKey("WorkPermit")]
        public string WorkPermitId { get; set; }
        public virtual WorkPermit WorkPermit { get; set; }
    }

    public class SancaoProfissional
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Natureza { get; set; }
        public DateTime? Data { get; set; }
        public string? Local { get; set; }
        public string? Detalhes { get; set; }

        [ForeignKey("WorkPermit")]
        public string WorkPermitId { get; set; }
        public virtual WorkPermit WorkPermit { get; set; }
    }

    public class CaymanConnection
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Relationship { get; set; }
        public string? Address { get; set; }

        [ForeignKey("WorkPermit")]
        public string WorkPermitId { get; set; }
        public virtual WorkPermit WorkPermit { get; set; }
    }
}

namespace app_blazor.Data.Entidades
{
    public class Dependente
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Nacionalidade")]
        public string? Nacionalidade { get; set; }

        [Display(Name = "Relação")]
        public string? Relacao { get; set; }

        [Display(Name = "País de Residência")]
        public string? PaisResidencia { get; set; }

        [Display(Name = "Adicionar ao Visto")]
        public bool AdicionarAoVisto { get; set; } = false;

        [Display(Name = "Não Adicionar ao Visto")]
        [NotMapped]
        public bool NaoAdicionarAoVisto
        {
            get => !AdicionarAoVisto;
            set => AdicionarAoVisto = !value;
        }

        // Referência para o WorkPermit
        [ForeignKey("WorkPermit")]
        public string WorkPermitId { get; set; }

        public virtual WorkPermit WorkPermit { get; set; }
    }
}

namespace app_blazor.Data.Entidades
{
    //public class Ofensa
    //{
    //    [Key]
    //    public string Id { get; set; } = Guid.NewGuid().ToString();
    //    public string? Natureza { get; set; }
    //    public DateTime? Data { get; set; }
    //    public string? Local { get; set; }
    //    public string? Detalhes { get; set; }

    //    [ForeignKey("WorkPermit")]
    //    public string WorkPermitId { get; set; }
    //    public virtual WorkPermit WorkPermit { get; set; }
    //}

    public class Ofensa
    {
        public Ofensa()
        {
            Id = Guid.NewGuid().ToString();
            WorkPermitId = string.Empty;
            WorkPermitDependentId = string.Empty;
        }

        [Key]
        public string Id { get; set; }
        public string Natureza { get; set; } = string.Empty;
        public DateTime? Data { get; set; }
        public string Local { get; set; } = string.Empty;
        public string Sentenca { get; set; } = string.Empty;
        public bool IsDependantOffense { get; set; }
        public string? Detalhes { get; set; }
        [ForeignKey("WorkPermit")]
        public string WorkPermitId { get; set; }
        public virtual WorkPermit? WorkPermit { get; set; }

        [ForeignKey("WorkPermitDependent")]
        public string WorkPermitDependentId { get; set; }
        public virtual WorkPermit? WorkPermitDependent { get; set; }
    }
}

namespace app_blazor.Data.Entidades
{
    public class ResidenciaAnterior
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Pais { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Endereco { get; set; }

        [ForeignKey("WorkPermit")]
        public string WorkPermitId { get; set; }
        public virtual WorkPermit WorkPermit { get; set; }
    }
}

namespace app_blazor.Data.ViewModels
{
    public class WorkPermitViewModel
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public int PaginaAtual { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Completo { get; set; }

        public Page1ViewModel Page1 { get; set; } = new();
        public Page2ViewModel Page2 { get; set; } = new();
        public Page3ViewModel Page3 { get; set; } = new();
        public Page4ViewModel Page4 { get; set; } = new();
        public Page5ViewModel Page5 { get; set; } = new();
        public Page6ViewModel Page6 { get; set; } = new();
    }

    public class Page1ViewModel
    {
        [Display(Name = "Surname")]
        public string? Surname { get; set; }

        [Display(Name = "Maiden Name")]
        public string? MaidenName { get; set; }

        [Display(Name = "Given Names")]
        public string? GivenNames { get; set; }

        [Display(Name = "Nationality")]
        public string? Nationality { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string? Gender { get; set; }

        [Display(Name = "Passport Number")]
        public string? PassportNumber { get; set; }

        [Display(Name = "Date of Issue")]
        [DataType(DataType.Date)]
        public DateTime? PassportDateIssue { get; set; }

        [Display(Name = "Place of Issue")]
        public string? PassportPlaceIssue { get; set; }

        [Display(Name = "Date of Expiry")]
        [DataType(DataType.Date)]
        public DateTime? PassportDateExpiry { get; set; }

        [Display(Name = "Known by other names")]
        public bool HasOtherNames { get; set; }

        [Display(Name = "Other Names")]
        public string? OtherNames { get; set; }

        [Display(Name = "House Number")]
        public string? HouseNumber { get; set; }

        [Display(Name = "Street Name")]
        public string? StreetName { get; set; }

        [Display(Name = "District")]
        public string? District { get; set; }

        [Display(Name = "PO Box")]
        public string? POBox { get; set; }

        [Display(Name = "Telephone")]
        public string? Telephone { get; set; }

        [Display(Name = "Has Email")]
        public bool HasEmail { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Marital Status")]
        public string? MaritalStatus { get; set; }

        [Display(Name = "Spouse Information")]
        public string? SpouseInfo { get; set; }

        [Display(Name = "Position Applied For")]
        public string? PositionAppliedFor { get; set; }

        [Display(Name = "Relevant Experience")]
        public string? RelevantExperience { get; set; }

        [Display(Name = "Years of Experience")]
        public int? YearsExperience { get; set; }

        [Display(Name = "Has Pending Appeal")]
        public bool HasPendingAppeal { get; set; }

        [Display(Name = "Appeal Details")]
        public string? AppealDetails { get; set; }

        public List<DependenteViewModel> Dependents { get; set; } = new();
    }

    public class Page2ViewModel
    {
        [Display(Name = "Has Criminal Record")]
        public bool HasCriminalRecord { get; set; }

        public List<OfensaViewModel> CriminalOffenses { get; set; } = new();
        public List<OfensaViewModel> DependantsCriminalOffenses { get; set; } = new();

        [Display(Name = "Deported from Cayman")]
        public bool DeportedFromCayman { get; set; }
        public string? CaymanDeportationDetails { get; set; }

        [Display(Name = "Deported from Other Country")]
        public bool DeportedFromOtherCountry { get; set; }
        public string? OtherCountryDeportationDetails { get; set; }

        [Display(Name = "Has Administrative Fines")]
        public bool HasAdministrativeFines { get; set; }
        public List<MultaAdministrativaViewModel> AdministrativeFines { get; set; } = new();

        [Display(Name = "Has Professional Sanctions")]
        public bool HasProfessionalSanctions { get; set; }
        public List<SancaoProfissionalViewModel> ProfessionalSanctions { get; set; } = new();

        [Display(Name = "Named as Dependant")]
        public bool WasNamedAsDependant { get; set; }
        public string? PermitHolderName { get; set; }

        [Display(Name = "Left Cayman Islands")]
        public bool LeftCaymanIslands { get; set; }
        public string? AbsenceDetails { get; set; }

        [Display(Name = "Dependants Criminal Record")]
        public bool DependantsCriminalRecord { get; set; }

        public List<ResidenciaAnteriorViewModel> PreviousResidences { get; set; } = new();

        public bool? HasDependants { get; set; }
        public bool? HasOtherNationality { get; set; }
        public string? OtherNationalityDetails { get; set; }
        public bool? HasCriminalOffence { get; set; }
        public string? CriminalOffenceDetails { get; set; }
        public bool? HasDeportation { get; set; }
        public string? DeportationDetails { get; set; }
    }

    public class Page3ViewModel
    {
        [Display(Name = "Caymanian Connections")]
        public bool? HasCaymanianConnections { get; set; }

        [Display(Name = "Caymanian Connection Details")]
        public string? CaymanianConnectionDetails { get; set; }

        public List<CaymanConnectionViewModel> CaymanConnections { get; set; } = new();

        [Display(Name = "Is English Native Language")]
        public bool? IsEnglishNativeLanguage { get; set; }

        [Display(Name = "Native Language")]
        public string? NativeLanguage { get; set; }

        [Display(Name = "Speaks English")]
        public bool? SpeaksEnglish { get; set; }

        [Display(Name = "Reads English")]
        public bool? ReadsEnglish { get; set; }

        [Display(Name = "Writes English")]
        public bool? WritesEnglish { get; set; }

        [Display(Name = "Currently On Island")]
        public bool? CurrentlyOnIsland { get; set; }

        [Display(Name = "IELTS Tested")]
        public bool? IELTSTested { get; set; }

        [Display(Name = "IELTS Score")]
        public string? IELTSScore { get; set; }

        [Display(Name = "IELTS Report Number")]
        public string? IELTSReportNumber { get; set; }

        [Display(Name = "IELTS Exam Date")]
        [DataType(DataType.Date)]
        public DateTime? IELTSExamDate { get; set; }

        [Display(Name = "TOEIC Tested")]
        public bool? TOEICTested { get; set; }

        [Display(Name = "TOEIC Score")]
        public string? TOEICScore { get; set; }

        [Display(Name = "TOEIC Report Number")]
        public string? TOEICReportNumber { get; set; }

        [Display(Name = "TOEIC Exam Date")]
        [DataType(DataType.Date)]
        public DateTime? TOEICExamDate { get; set; }

        [Display(Name = "Good Physical and Mental Health")]
        public bool? GoodPhysicalMentalHealth { get; set; }

        [Display(Name = "Health Details")]
        public string? HealthDetails { get; set; }

        [Display(Name = "Dependants Good Health")]
        public bool? DependantsGoodHealth { get; set; }

        [Display(Name = "Dependants Health Details")]
        public string? DependantsHealthDetails { get; set; }

        [Display(Name = "Tested Positive for HIV or STD")]
        public bool? TestedPositiveSTD { get; set; }

        [Display(Name = "STD Test Details")]
        public string? STDTestDetails { get; set; }

        [Display(Name = "Accept Terms and Conditions")]
        public bool AcceptTerms { get; set; }

        [Display(Name = "Signature Date")]
        [DataType(DataType.Date)]
        public DateTime? SignatureDate { get; set; }
    }

    public class Page4ViewModel
    {
        [Display(Name = "Is Company")]
        public bool? IsCompany { get; set; }

        [Display(Name = "Company Name")]
        public string? CompanyName { get; set; }

        [Display(Name = "Nature of Business")]
        public string? NatureOfBusiness { get; set; }

        [Display(Name = "Company PO Box")]
        public string? CompanyPOBox { get; set; }

        [Display(Name = "Company Physical Address")]
        public string? CompanyPhysicalAddress { get; set; }

        [Display(Name = "Company Email")]
        public string? CompanyEmail { get; set; }

        [Display(Name = "Company Telephone")]
        public string? CompanyTelephone { get; set; }

        [Display(Name = "Business License Law")]
        public string? BusinessLicenseLaw { get; set; }

        [Display(Name = "License Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime? LicenseExpiryDate { get; set; }

        [Display(Name = "License Number")]
        public string? LicenseNumber { get; set; }

        [Display(Name = "Employee Is Shareholder")]
        public bool? EmployeeIsShareholder { get; set; }

        [Display(Name = "Shareholder Remuneration Yes/No")]
        public string? ShareholderRemunerationYesNo { get; set; }

        [Display(Name = "Shareholder Remuneration Details")]
        public string? ShareholderRemunerationDetails { get; set; }

        [Display(Name = "Personal Employer Name")]
        public string? PersonalEmployerName { get; set; }

        [Display(Name = "Personal Employer Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? PersonalEmployerDateOfBirth { get; set; }

        [Display(Name = "Personal Employer PO Box")]
        public string? PersonalEmployerPOBox { get; set; }

        [Display(Name = "Personal Employer Telephone")]
        public string? PersonalEmployerTelephone { get; set; }

        [Display(Name = "Personal Employer Email")]
        public string? PersonalEmployerEmail { get; set; }

        [Display(Name = "Personal Employer Occupation")]
        public string? PersonalEmployerOccupation { get; set; }

        [Display(Name = "Personal Employer's Employer Name")]
        public string? PersonalEmployerEmployerName { get; set; }

        [Display(Name = "Personal Employer's Employer PO Box")]
        public string? PersonalEmployerEmployerPOBox { get; set; }

        [Display(Name = "Personal Employer's Employer Telephone")]
        public string? PersonalEmployerEmployerTelephone { get; set; }

        [Display(Name = "Is Permit Shared")]
        public bool? IsPermitShared { get; set; }

        [Display(Name = "Additional Employer Name")]
        public string? AdditionalEmployerName { get; set; }

        [Display(Name = "Additional Employer Phone")]
        public string? AdditionalEmployerPhone { get; set; }

        [Display(Name = "Additional Employer Email")]
        public string? AdditionalEmployerEmail { get; set; }

        [Display(Name = "Additional Employer Is Person")]
        public bool? AdditionalEmployerIsPerson { get; set; }

        [Display(Name = "Additional Employer Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? AdditionalEmployerDateOfBirth { get; set; }

        [Display(Name = "Position with Additional Employer")]
        public string? PositionWithAdditionalEmployer { get; set; }

        [Display(Name = "Salary Currency Type")]
        public string? SalaryCurrencyType { get; set; }

        [Display(Name = "Salary Amount")]
        public decimal? SalaryAmount { get; set; }

        [Display(Name = "Salary Period")]
        public string? SalaryPeriod { get; set; }

        [Display(Name = "Hours with Additional Employer")]
        public int? HoursWithAdditionalEmployer { get; set; }

        [Display(Name = "Is Family Member")]
        public bool? IsFamilyMember { get; set; }

        [Display(Name = "Family Relationship")]
        public string? FamilyRelationship { get; set; }

        [Display(Name = "Occupation Description")]
        public string? OccupationDescription { get; set; }

        [Display(Name = "Required Skills")]
        public string? RequiredSkills { get; set; }

        [Display(Name = "Current Employees Count")]
        public int? CurrentEmployeesCount { get; set; }

        [Display(Name = "Caymanian Employees Count")]
        public int? CaymanianEmployeesCount { get; set; }

        [Display(Name = "Permanent Residents Count")]
        public int? PermanentResidentsCount { get; set; }

        [Display(Name = "Registered on JobsCayman")]
        public bool? RegisteredOnJobsCayman { get; set; }

        [Display(Name = "JobsCayman Job ID")]
        public string? JobsCaymanJobID { get; set; }
    }

    public class Page5ViewModel
    {
        [Display(Name = "Job Advertised")]
        public bool? JobAdvertised { get; set; }

        [Display(Name = "Caymanian Applied")]
        public bool? CaymanianApplied { get; set; }

        [Display(Name = "Why None Hired")]
        public string? WhyNoneHired { get; set; }

        [Display(Name = "Permit Duration")]
        public string? PermitDuration { get; set; }

        [Display(Name = "Permit Start Date")]
        [DataType(DataType.Date)]
        public DateTime? PermitStartDate { get; set; }

        [Display(Name = "Coincide With Spouse")]
        public bool? CoincideWithSpouse { get; set; }

        [Display(Name = "Salary Currency Type")]
        public string? SalaryCurrencyType { get; set; }

        [Display(Name = "Salary Amount")]
        public decimal? SalaryAmount { get; set; }

        [Display(Name = "Salary Period")]
        public string? SalaryPeriod { get; set; }

        [Display(Name = "Weekly Hours")]
        public int? WeeklyHours { get; set; }

        [Display(Name = "Other Benefits")]
        public string? OtherBenefits { get; set; }

        [Display(Name = "Lives With Employer")]
        public bool? LivesWithEmployer { get; set; }

        [Display(Name = "Has Gratuities Scheme")]
        public bool? HasGratuitiesScheme { get; set; }

        [Display(Name = "Non-English Speaking Country")]
        public bool? NonEnglishSpeakingCountry { get; set; }

        [Display(Name = "Aware Of English Test")]
        public bool? AwareOfEnglishTest { get; set; }

        [Display(Name = "Satisfied With English")]
        public bool? SatisfiedWithEnglish { get; set; }

        [Display(Name = "English Steps Taken")]
        public string? EnglishStepsTaken { get; set; }

        [Display(Name = "Employer Signature Date")]
        [DataType(DataType.Date)]
        public DateTime? EmployerSignatureDate { get; set; }

        [Display(Name = "Additional Signature Date")]
        [DataType(DataType.Date)]
        public DateTime? AdditionalSignatureDate { get; set; }
    }

    public class Page6ViewModel
    {
        [Display(Name = "Has Valid Pension Plan")]
        public bool? HasValidPensionPlan { get; set; }

        [Display(Name = "Pension Plan No Reason")]
        public string? PensionPlanNoReason { get; set; }

        [Display(Name = "Pension Company Name")]
        public string? PensionCompanyName { get; set; }

        [Display(Name = "Pension Company Phone")]
        public string? PensionCompanyPhone { get; set; }

        [Display(Name = "Pension Company Email")]
        public string? PensionCompanyEmail { get; set; }

        [Display(Name = "Employee Pension Number")]
        public string? EmployeePensionNo { get; set; }

        [Display(Name = "Pension Registration Number")]
        public string? PensionRegistrationNo { get; set; }

        [Display(Name = "Pension Plan Paid Up To Date")]
        public bool? PensionPlanPaidUpToDate { get; set; }

        [Display(Name = "Pension Plan Not Paid Reason")]
        public string? PensionPlanNotPaidReason { get; set; }

        [Display(Name = "Has Valid Health Insurance")]
        public bool? HasValidHealthInsurance { get; set; }

        [Display(Name = "Health Insurance No Reason")]
        public string? HealthInsuranceNoReason { get; set; }

        [Display(Name = "Health Insurance Company Name")]
        public string? HealthInsuranceCompanyName { get; set; }

        [Display(Name = "Health Insurance Company Phone")]
        public string? HealthInsuranceCompanyPhone { get; set; }

        [Display(Name = "Health Insurance Company Email")]
        public string? HealthInsuranceCompanyEmail { get; set; }

        [Display(Name = "Employee Health Membership Number")]
        public string? EmployeeHealthMembershipNo { get; set; }

        [Display(Name = "Health Insurance Policy Number")]
        public string? HealthInsurancePolicyNo { get; set; }

        [Display(Name = "Health Insurance Paid Up To Date")]
        public bool? HealthInsurancePaidUpToDate { get; set; }

        [Display(Name = "Health Insurance Not Paid Reason")]
        public string? HealthInsuranceNotPaidReason { get; set; }

        [Display(Name = "Employer Name")]
        public string? EmployerName { get; set; }

        [Display(Name = "Employer Print Name")]
        public string? EmployerPrintName { get; set; }

        [Display(Name = "Employer Signature Date")]
        public DateTime? EmployerSignatureDate { get; set; }

        [Display(Name = "Employee Name")]
        public string? EmployeeName { get; set; }

        [Display(Name = "Employee Signature Date")]
        public DateTime? EmployeeSignatureDate { get; set; }
    }

    public class DependenteViewModel
    {
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Relacao { get; set; }
        public string? PaisResidencia { get; set; }
        public bool AdicionarAoVisto { get; set; }
    }

    public class OfensaViewModel
    {
        public string? Natureza { get; set; }
        public DateTime? Data { get; set; }
        public string? Local { get; set; }
        public string? Detalhes { get; set; }
    }

    public class MultaAdministrativaViewModel
    {
        public string? Natureza { get; set; }
        public DateTime? Data { get; set; }
        public string? Local { get; set; }
        public decimal? Valor { get; set; }
    }

    public class SancaoProfissionalViewModel
    {
        public string? Natureza { get; set; }
        public DateTime? Data { get; set; }
        public string? Local { get; set; }
        public string? Detalhes { get; set; }
    }

    public class CaymanConnectionViewModel
    {
        public string? Name { get; set; }
        public string? Relationship { get; set; }
        public string? Address { get; set; }
    }

    public class ResidenciaAnteriorViewModel
    {
        public string? Pais { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Endereco { get; set; }
    }
}


namespace app_blazor.Servicos
{
    public class TestDataService
    {
        private readonly Random _random = new Random();
        private readonly ILogger<TestDataService> _logger;
        public TestDataService(ILogger<TestDataService> logger)
        {
            _logger = logger;
        }

        public async Task<List<WorkPermit>> GerarDadosDeTeste(int quantidade = 3)
        {
            List<WorkPermit> ids = new List<WorkPermit>();

            try
            {
                _logger.LogInformation($"Iniciando geração de {quantidade} registros de teste");

                for (int i = 0; i < quantidade; i++)
                {
                    _logger.LogInformation($"Gerando registro {i + 1} de {quantidade}");
                    var workPermit = GerarWorkPermitAleatorio();

                    _logger.LogInformation($"Salvando registro {workPermit.Id} - {workPermit.Page1_GivenNames} {workPermit.Page1_Surname}");

                    ids.Add(workPermit);
                    _logger.LogInformation($"Registro {i + 1} salvo com sucesso: {workPermit.Id}");
                }

                _logger.LogInformation($"Geração concluída: {ids.Count} registros criados");
                return ids;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao gerar dados de teste. Detalhe: {ex.Message}");
                throw; // Propaga a exceção para tratamento superior
            }
        }

        private WorkPermit GerarWorkPermitAleatorio()
        {
            try
            {
                // Criamos um novo formulário com ID gerado
                var workPermit = new WorkPermit
                {
                    //        Id = Guid.NewGuid().ToString(),
                    Status = _random.Next(10) < 3 ? "PDF Emitido" : "Finalizado",
                    PaginaAtual = 6, // Preenchimento completo
                    DataCriacao = DateTime.Now.AddDays(-_random.Next(1, 30)),
                    DataAtualizacao = DateTime.Now,
                    Completo = true,

                    // Lista vazia de dependentes para garantir inicialização correta
                    Page1_Dependents = new List<Dependente>(),

                    // Dados Pessoais
                    Page1_Surname = ObterSobrenomeAleatorio(),
                    Page1_GivenNames = ObterNomeAleatorio(),
                    Page1_Nationality = ObterNacionalidadeAleatoria(),
                    Page1_DateOfBirth = DateTime.Now.AddYears(-_random.Next(25, 65)).AddDays(-_random.Next(1, 365)),
                    Page1_Gender = _random.Next(2) == 0 ? "Male" : "Female",

                    // Passaporte
                    Page1_PassportNumber = GerarPassaporteAleatorio(),
                    Page1_PassportDateIssue = DateTime.Now.AddYears(-_random.Next(1, 9)).AddMonths(-_random.Next(0, 11)),
                    Page1_PassportPlaceIssue = ObterCidadeAleatoria(),

                    // Outros nomes
                    Page1_HasOtherNames = _random.Next(5) == 0,

                    // Endereço e contato
                    Page1_HouseNumber = _random.Next(1, 999).ToString(),
                    Page1_StreetName = $"{ObterNomeDeRuaAleatorio()} Street",
                    Page1_District = ObterDistritoAleatorio(),
                    Page1_POBox = $"P.O.Box {_random.Next(1000, 9999)}",
                    Page1_Telephone = GerarTelefoneAleatorio(),
                    Page1_HasEmail = true,
                    Page1_Email = GerarEmailAleatorio(),

                    // Estado civil
                    Page1_MaritalStatus = ObterEstadoCivilAleatorio(),

                    // Experiência profissional
                    Page1_PositionAppliedFor = ObterCargoAleatorio(),
                    Page1_RelevantExperience = GerarExperienciaProfissionalAleatoria(),
                    Page1_YearsExperience = _random.Next(2, 25),
                    Page1_HasPendingAppeal = false,

                    // Dados do Empregador
                    Page4_IsCompany = true,
                    Page4_CompanyName = ObterNomeEmpresaAleatorio(),
                    Page4_NatureOfBusiness = ObterSetorEmpresarialAleatorio(),
                    Page4_CompanyPOBox = $"P.O.Box {_random.Next(1000, 9999)}",
                    Page4_CompanyPhysicalAddress = $"{ObterNomeDeRuaAleatorio()} St, {ObterDistritoAleatorio()}",
                    Page4_CompanyEmail = GerarEmailEmpresarialAleatorio(),
                    Page4_CompanyTelephone = GerarTelefoneAleatorio(),
                    Page4_CurrentEmployeesCount = _random.Next(5, 200),
                    Page4_CaymanianEmployeesCount = _random.Next(2, 50),

                    // Detalhes do Trabalho
                    Page5_JobAdvertised = true,
                    Page5_CaymanianApplied = _random.Next(2) == 0,
                    Page5_PermitDuration = ObterDuracaoPermissaoAleatoria(),
                    Page5_PermitStartDate = DateTime.Now.AddDays(_random.Next(15, 60)),
                    Page5_SalaryCurrencyType = "CI$",
                    Page5_SalaryAmount = _random.Next(30000, 120000),
                    Page5_SalaryPeriod = "annual",
                    Page5_WeeklyHours = 40,

                    // Plano de Saúde e Aposentadoria
                    Page6_HasValidHealthInsurance = true,
                    Page6_HealthInsuranceCompanyName = ObterSeguradoraAleatoria(),
                    Page6_HasValidPensionPlan = true,
                    Page6_PensionCompanyName = ObterFundoDePensaoAleatorio()
                };

                // Calcula a data de expiração do passaporte (10 anos após a emissão)
                if (workPermit.Page1_PassportDateIssue.HasValue)
                {
                    workPermit.Page1_PassportDateExpiry = workPermit.Page1_PassportDateIssue.Value.AddYears(10);
                }

                // Gera dependentes aleatórios
                var dependentes = GerarDependentesAleatorios(_random.Next(0, 3));
                foreach (var dependente in dependentes)
                {
                    dependente.WorkPermitId = workPermit.Id;
                    workPermit.Page1_Dependents.Add(dependente);
                }

                // Dados adicionais para casos de PDF emitido
                if (workPermit.Status == "PDF Emitido")
                {
                    string nomeArquivoGerado = $"pagina1_{workPermit.Id}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    var dadosPdf = new
                    {
                        caminhoArquivo = "pdfs_gerados/" + nomeArquivoGerado,
                        dataGeracao = DateTime.Now,
                        nomeArquivo = nomeArquivoGerado
                    };
                    workPermit.DadosAdicionais = System.Text.Json.JsonSerializer.Serialize(dadosPdf);
                }

                _logger.LogInformation($"Formulário gerado com sucesso: {workPermit.Id} - {workPermit.Page1_GivenNames} {workPermit.Page1_Surname} com {workPermit.Page1_Dependents.Count} dependentes");
                return workPermit;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao gerar formulário aleatório");
                throw;
            }
        }

        private List<Dependente> GerarDependentesAleatorios(int quantidade)
        {
            List<Dependente> dependentes = new List<Dependente>();

            for (int i = 0; i < quantidade; i++)
            {
                dependentes.Add(new Dependente
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = $"{ObterNomeAleatorio()} {ObterSobrenomeAleatorio()}",
                    DataNascimento = DateTime.Now.AddYears(-_random.Next(1, 18)).AddDays(-_random.Next(1, 365)),
                    Nacionalidade = ObterNacionalidadeAleatoria(),
                    Relacao = ObterRelacaoAleatoria(),
                    PaisResidencia = "Cayman Islands",
                    AdicionarAoVisto = true
                });
            }

            return dependentes;
        }

        #region Geradores de Dados Aleatórios

        private string ObterNomeAleatorio()
        {
            string[] nomesMasculinos = { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles", "Daniel", "Matthew", "Anthony", "Mark", "Donald", "Steven", "Andrew", "Carlos", "Eduardo", "João" };
            string[] nomesFemininos = { "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen", "Lisa", "Nancy", "Betty", "Sandra", "Margaret", "Ana", "Maria", "Sofia", "Isabela", "Camila" };

            if (_random.Next(2) == 0)
                return nomesMasculinos[_random.Next(nomesMasculinos.Length)];
            else
                return nomesFemininos[_random.Next(nomesFemininos.Length)];
        }

        private string ObterSobrenomeAleatorio()
        {
            string[] sobrenomes = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Silva", "Santos", "Costa", "Pereira", "Oliveira" };
            return sobrenomes[_random.Next(sobrenomes.Length)];
        }

        private string ObterNacionalidadeAleatoria()
        {
            string[] nacionalidades = { "American", "British", "Canadian", "Australian", "Brazilian", "Mexican", "Filipino", "Indian", "Jamaican", "Spanish", "German", "French", "Italian", "Chinese", "Japanese", "South African", "Portuguese", "Colombian", "Venezuelan", "Chilean" };
            return nacionalidades[_random.Next(nacionalidades.Length)];
        }

        private string GerarPassaporteAleatorio()
        {
            string letras = new string(Enumerable.Range(0, 2)
                .Select(_ => (char)_random.Next('A', 'Z' + 1))
                .ToArray());

            string numeros = new string(Enumerable.Range(0, 7)
                .Select(_ => (char)_random.Next('0', '9' + 1))
                .ToArray());

            return $"{letras}{numeros}";
        }

        private string ObterCidadeAleatoria()
        {
            string[] cidades = { "New York", "London", "Toronto", "Sydney", "Rio de Janeiro", "Mexico City", "Manila", "Mumbai", "Kingston", "Madrid", "Berlin", "Paris", "Rome", "Beijing", "Tokyo", "Cape Town", "Lisbon", "Bogotá", "Caracas", "Santiago" };
            return cidades[_random.Next(cidades.Length)];
        }

        private string ObterNomeDeRuaAleatorio()
        {
            string[] nomes = { "Main", "Oak", "Pine", "Maple", "Cedar", "Elm", "Palm", "Beach", "Ocean", "Mountain", "River", "Park", "Garden", "Church", "School", "Market", "Harbor", "Bay", "Lake", "Hill" };
            return nomes[_random.Next(nomes.Length)];
        }

        private string ObterDistritoAleatorio()
        {
            string[] distritos = { "George Town", "West Bay", "Bodden Town", "East End", "North Side", "Seven Mile Beach", "South Sound", "Savannah", "Prospect", "Red Bay" };
            return distritos[_random.Next(distritos.Length)];
        }

        private string GerarTelefoneAleatorio()
        {
            return $"+1-345-{_random.Next(100, 999)}-{_random.Next(1000, 9999)}";
        }

        private string GerarEmailAleatorio()
        {
            string[] dominios = { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com", "aol.com", "icloud.com" };
            string nome = ObterNomeAleatorio().ToLower();
            string sobrenome = ObterSobrenomeAleatorio().ToLower();
            string dominio = dominios[_random.Next(dominios.Length)];

            int tipo = _random.Next(4);
            switch (tipo)
            {
                case 0: return $"{nome}.{sobrenome}@{dominio}";
                case 1: return $"{nome}{_random.Next(10, 999)}@{dominio}";
                case 2: return $"{nome[0]}{sobrenome}@{dominio}";
                default: return $"{nome}_{sobrenome}@{dominio}";
            }
        }

        private string ObterEstadoCivilAleatorio()
        {
            string[] estadosCivis = { "Single", "Married", "Divorced", "Separated", "Civil Partnership", "Dissolved Civil Partnership" };
            return estadosCivis[_random.Next(estadosCivis.Length)];
        }

        private string ObterCargoAleatorio()
        {
            string[] cargos = { "Chef", "Restaurant Manager", "Financial Analyst", "Software Developer", "Accountant", "Marketing Manager", "Hotel Manager", "Teacher", "Nurse", "Administrative Assistant", "Customer Service Representative", "Sales Manager", "Construction Manager", "Electrician", "Engineer", "Marine Biologist", "Diving Instructor", "Tour Guide", "Real Estate Agent", "Financial Advisor" };
            return cargos[_random.Next(cargos.Length)];
        }

        private string GerarExperienciaProfissionalAleatoria()
        {
            int anos = _random.Next(2, 25);
            string cargo = ObterCargoAleatorio();

            string[] empresas = { "Global Solutions Inc.", "International Group", "Premier Services", "Elite Management", "Superior Corporation", "Prime Industries", "Ocean Enterprises", "Island Services Ltd.", "Caribbean Resources", "Tropical Ventures" };
            string empresa = empresas[_random.Next(empresas.Length)];

            string[] habilidades = { "customer service", "team management", "project coordination", "budget oversight", "staff training", "quality control", "inventory management", "process improvement", "client relations", "strategic planning" };
            string habilidade1 = habilidades[_random.Next(habilidades.Length)];
            string habilidade2 = habilidades[_random.Next(habilidades.Length)];

            return $"{anos} years of experience as a {cargo} with expertise in {habilidade1} and {habilidade2}. Previously worked at {empresa} managing daily operations and ensuring compliance with industry standards.";
        }

        private string ObterRelacaoAleatoria()
        {
            string[] relacoes = { "Son", "Daughter", "Spouse", "Child", "Stepchild" };
            return relacoes[_random.Next(relacoes.Length)];
        }

        private string ObterNomeEmpresaAleatorio()
        {
            string[] prefixos = { "Cayman", "Island", "Caribbean", "Tropical", "Blue Water", "Coral", "Seven Mile", "Palm", "Ocean", "Bay" };
            string[] tipos = { "Solutions", "Enterprises", "Industries", "Services", "Group", "Holdings", "Resources", "Ventures", "Management", "Properties" };

            return $"{prefixos[_random.Next(prefixos.Length)]} {tipos[_random.Next(tipos.Length)]}";
        }

        private string ObterSetorEmpresarialAleatorio()
        {
            string[] setores = { "Financial Services", "Tourism & Hospitality", "Real Estate", "Banking", "Insurance", "Retail", "Construction", "Food & Beverage", "Healthcare", "Education", "IT Services", "Marine Services", "Legal Services", "Accounting" };
            return setores[_random.Next(setores.Length)];
        }

        private string GerarEmailEmpresarialAleatorio()
        {
            string nome = ObterNomeEmpresaAleatorio().Replace(" ", "").ToLower();
            string[] dominios = { "company.com", "business.ky", "group.com", "corp.ky", "enterprise.com" };
            return $"info@{nome}.{dominios[_random.Next(dominios.Length)].Split('.')[1]}";
        }

        private string ObterDuracaoPermissaoAleatoria()
        {
            string[] duracoes = { "1 year", "2 years", "3 years", "5 years" };
            return duracoes[_random.Next(duracoes.Length)];
        }

        private string ObterSeguradoraAleatoria()
        {
            string[] seguradoras = { "Cayman Health Insurance", "Island Care", "Caribbean Health Plan", "Blue Cross Cayman", "Global Health Partners", "Premier Medical Insurance", "Island Protection Plan" };
            return seguradoras[_random.Next(seguradoras.Length)];
        }

        private string ObterFundoDePensaoAleatorio()
        {
            string[] fundos = { "Cayman Pension Services", "Island Retirement Fund", "Caribbean Pension Solutions", "Premier Retirement Group", "Global Pension Management", "Silver Horizon Pension Fund" };
            return fundos[_random.Next(fundos.Length)];
        }

        #endregion
    }
}

namespace app_blazor.Servicos
{

    public interface IPdfService
    {
        Task<string> PreencherPdf1Async(WorkPermit workPermit, bool modoPreview = false, string modeloPdfPath = "");
        Task<MemoryStream> PreviewPdf1Async(WorkPermit workPermit);
    }

    /// <summary>
    /// Serviço para manipulação de arquivos PDF
    /// </summary>
    public class PdfService : IPdfService
    {
        private readonly ILogger<PdfService> _logger;
        private readonly IHostEnvironment _hostingEnvironment;
        private Dictionary<string, string> _camposMapeados;

        public PdfService(ILogger<PdfService> logger, IHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _camposMapeados = new Dictionary<string, string>();
        }


        public async Task<object> PreencherPdfAsync(WorkPermit workPermit, bool modoPreview = false, string modeloPdfPath = "")
        {
            try
            {
                // Garantir que a pasta para PDFs gerados exista
                string pastaPdfsGerados = Path.Combine(_hostingEnvironment.ContentRootPath, "pdfs_gerados");
                if (!Directory.Exists(pastaPdfsGerados))
                {
                    Directory.CreateDirectory(pastaPdfsGerados);
                }

                // Caminho do arquivo PDF modelo
                //string modeloPdfPath = Path.Combine(_hostingEnvironment.ContentRootPath, "AppJS", "pdf", "pg2.pdf");

                // Nome para o arquivo gerado (usando ID do formulário e timestamp para torná-lo único)
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss") + (modoPreview ? "_preview" : "");
                // string nomeArquivoGerado = $"pagina1_{workPermit.Id}_{timestamp}.pdf";
                string nomeArquivoGerado = $"preview.pdf";
                string pdfGeradoPath = Path.Combine(pastaPdfsGerados, nomeArquivoGerado);

                // Se estiver em modo preview, usar um MemoryStream
                MemoryStream memoryStream = modoPreview ? new MemoryStream() : null;

                // Abrir o PDF original e criar um novo para salvar as alterações
                using (PdfReader pdfReader = new PdfReader(modeloPdfPath))
                {
                    PdfWriter pdfWriter;
                    pdfWriter = new PdfWriter(pdfGeradoPath);

                    using (PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter))
                    {
                        // Manipular campos do formulário
                        PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDocument, true);

                        // Inicializar mapeamento de campos
                        InicializarMapeamento();

                        if (form != null)
                        {
                            var campos = form.GetAllFormFields();

                            _logger.LogInformation($"Iniciando preenchimento do PDF. Total de campos: {campos.Count}");

                            PreencherPagina_1(workPermit, campos);

                            // PÁGINA 2 - PREENCHIMENTO

                            PreecherPagina_2(workPermit, campos);

                            foreach (var campo in campos)
                            {
                                PdfFormField campo_saida = campos[campo.Key];
                                campo_saida.SetValue(campo.Key);
                            }

                            // Aplica as mudanças e preserva a aparência do formulário
                            form.FlattenFields();

                            _logger.LogInformation($"PDF preenchido com sucesso: {(modoPreview ? "MemoryStream" : pdfGeradoPath)}");
                        }
                        else
                        {
                            _logger.LogWarning("Nenhum formulário encontrado no PDF modelo.");
                        }

                        // Fecha o documento
                        pdfDocument.Close();
                    }
                }

                // Se não estiver em modo preview, salvar o Base64 no WorkPermit
                if (!modoPreview)
                {
                    try
                    {
                        // Armazenar o caminho relativo em vez do absoluto
                        string caminhoRelativo = Path.Combine("pdfs_gerados", nomeArquivoGerado);

                        // Salvar apenas as informações do caminho do arquivo
                        var dadosPdf = new
                        {
                            caminhoArquivo = caminhoRelativo, // Caminho relativo
                            dataGeracao = DateTime.Now,
                            nomeArquivo = nomeArquivoGerado
                        };

                        // Converter para JSON e salvar na propriedade DadosAdicionais
                        workPermit.DadosAdicionais = JsonSerializer.Serialize(dadosPdf);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro ao salvar informações do PDF: {Message}", ex.Message);
                    }
                }

                // Caso contrário, retorna o caminho do arquivo gerado
                return pdfGeradoPath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao preencher PDF: {Message}", ex.Message);
                throw;
            }
        }

        private void PreecherPagina_2(WorkPermit workPermit, IDictionary<string, PdfFormField> campos)
        {
            // Questão 10 - Ofensas Criminais
            if (workPermit.Page2_HasCriminalRecord == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_CriminalRecord_Yes"], "Yes");

                // Preencher detalhes das ofensas criminais
                var ofensas = workPermit.Page2_CriminalOffenses.ToList();

                // Primeira ofensa criminal
                if (ofensas.Count > 0)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_0_Nature"], ofensas[0].Natureza);

                    if (ofensas[0].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_0_Date"],
                            ofensas[0].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_0_Location"], ofensas[0].Local);
                    PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_0_Verdict"], ofensas[0].Sentenca);
                }

                // Segunda ofensa criminal
                if (ofensas.Count > 1)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_1_Nature"], ofensas[1].Natureza);

                    if (ofensas[1].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_1_Date"],
                            ofensas[1].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_1_Location"], ofensas[1].Local);
                    PreencherCampo(campos, _camposMapeados["Page2_CriminalOffense_1_Verdict"], ofensas[1].Sentenca);
                }
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_CriminalRecord_No"], "Yes");
            }

            // Questão 11 - Deportação

            // Parte (a) - Ilhas Cayman
            if (workPermit.Page2_DeportedFromCayman == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_DeportedCayman_Yes"], "Yes");
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_DeportedCayman_No"], "Yes");
            }

            // Parte (b) - Outros países
            if (workPermit.Page2_DeportedFromOtherCountry == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_DeportedOtherCountry_Yes"], "Yes");
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_DeportedOtherCountry_No"], "Yes");
            }

            // Detalhes de deportação
            if (workPermit.Page2_DeportedFromCayman == true || workPermit.Page2_DeportedFromOtherCountry == true)
            {
                string detalhesDeportacao = "";

                if (workPermit.Page2_DeportedFromCayman == true)
                {
                    detalhesDeportacao += "Cayman: " + workPermit.Page2_CaymanDeportationDetails + "; ";
                }

                if (workPermit.Page2_DeportedFromOtherCountry == true)
                {
                    detalhesDeportacao += "Other country: " + workPermit.Page2_OtherCountryDeportationDetails;
                }

                PreencherCampo(campos, _camposMapeados["Page2_DeportationDetails"], detalhesDeportacao);
            }

            // Questão 12 - Multas Administrativas
            if (workPermit.Page2_HasAdministrativeFines == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_AdminFines_Yes"], "Yes");

                // Preencher detalhes das multas administrativas
                var multas = workPermit.Page2_AdministrativeFines.ToList();

                // Primeira multa
                if (multas.Count > 0)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_AdminFine_0_Nature"], multas[0].Natureza);

                    if (multas[0].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_AdminFine_0_Date"],
                            multas[0].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_AdminFine_0_Location"], multas[0].Local);
                    PreencherCampo(campos, _camposMapeados["Page2_AdminFine_0_Amount"], multas[0].Valor.ToString());
                }

                // Segunda multa
                if (multas.Count > 1)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_AdminFine_1_Nature"], multas[1].Natureza);

                    if (multas[1].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_AdminFine_1_Date"],
                            multas[1].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_AdminFine_1_Location"], multas[1].Local);
                    PreencherCampo(campos, _camposMapeados["Page2_AdminFine_1_Amount"], multas[1].Valor.ToString());
                }
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_AdminFines_No"], "Yes");
            }

            // Questão 13 - Sanções Profissionais
            if (workPermit.Page2_HasProfessionalSanctions == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_ProfessionalSanctions_Yes"], "Yes");

                // Preencher detalhes das sanções profissionais
                var sancoes = workPermit.Page2_ProfessionalSanctions.ToList();

                // Primeira sanção
                if (sancoes.Count > 0)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_0_Nature"], sancoes[0].Natureza);

                    if (sancoes[0].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_0_Date"],
                            sancoes[0].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_0_Location"], sancoes[0].Local);
                    PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_0_Reasons"], sancoes[0].Detalhes);
                }

                // Segunda sanção
                if (sancoes.Count > 1)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_1_Nature"], sancoes[1].Natureza);

                    if (sancoes[1].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_1_Date"],
                            sancoes[1].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_1_Location"], sancoes[1].Local);
                    PreencherCampo(campos, _camposMapeados["Page2_ProfSanction_1_Reasons"], sancoes[1].Detalhes);
                }
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_ProfessionalSanctions_No"], "Yes");
            }

            // Questão 14 - Dependente de permissão de trabalho
            /*
            if (workPermit.Page2_DependantOnPermit == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_DependantOnPermit_Yes"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page2_PermitHolderName"], workPermit.Page2_PermitHolderName);
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_DependantOnPermit_No"], "Yes");
            }
            */

            // Questão 11 - Dependente de permissão de trabalho (Named as dependant)
            if (workPermit.Page2_HasOtherNationality == true) // Usando essa propriedade como substituta temporária
            {
                PreencherCampo(campos, _camposMapeados["Page2_DependantOnPermit_Yes"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page2_PermitHolderName"], workPermit.Page2_OtherNationalityDetails); // Usando essa propriedade como substituta temporária
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_DependantOnPermit_No"], "Yes");
            }

            // Questão 15 - Ausência das Ilhas Cayman
            /*
            if (workPermit.Page2_LeftCayman == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_LeftCayman_Yes"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page2_AbsenceDetails"], workPermit.Page2_AbsenceDetails);
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_LeftCayman_No"], "Yes");
            }
            */

            // Questão 12 - Ausência das Ilhas Cayman por mais de 1 ano
            if (workPermit.Page2_HasCriminalOffence == true) // Usando essa propriedade como substituta temporária
            {
                PreencherCampo(campos, _camposMapeados["Page2_LeftCayman_Yes"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page2_AbsenceDetails"], workPermit.Page2_CriminalOffenceDetails); // Usando essa propriedade como substituta temporária
                PreencherCampo(campos, _camposMapeados["Page2_AbsenceReasons"], workPermit.Page2_CriminalOffenceDetails); // Usando essa propriedade como substituta temporária
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_LeftCayman_No"], "Yes");
            }

            // Histórico de Residências (questão 14 na imagem)
            var residencias = workPermit.Page2_PreviousResidences.ToList();

            // Preencher dados da primeira residência
            if (residencias.Count > 0)
            {
                if (residencias[0].DataInicio.HasValue)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_Residence_0_From"],
                        residencias[0].DataInicio.Value.ToString("dd/MM/yyyy"));
                }

                if (residencias[0].DataFim.HasValue)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_Residence_0_To"],
                        residencias[0].DataFim.Value.ToString("dd/MM/yyyy"));
                }

                PreencherCampo(campos, _camposMapeados["Page2_Residence_0_Address"], residencias[0].Endereco);
            }

            // Preencher dados da segunda residência
            if (residencias.Count > 1)
            {
                if (residencias[1].DataInicio.HasValue)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_Residence_1_From"],
                        residencias[1].DataInicio.Value.ToString("dd/MM/yyyy"));
                }

                if (residencias[1].DataFim.HasValue)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_Residence_1_To"],
                        residencias[1].DataFim.Value.ToString("dd/MM/yyyy"));
                }

                PreencherCampo(campos, _camposMapeados["Page2_Residence_1_Address"], residencias[1].Endereco);
            }

            // Preencher dados da terceira residência
            if (residencias.Count > 2)
            {
                if (residencias[2].DataInicio.HasValue)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_Residence_2_From"],
                        residencias[2].DataInicio.Value.ToString("dd/MM/yyyy"));
                }

                if (residencias[2].DataFim.HasValue)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_Residence_2_To"],
                        residencias[2].DataFim.Value.ToString("dd/MM/yyyy"));
                }

                PreencherCampo(campos, _camposMapeados["Page2_Residence_2_Address"], residencias[2].Endereco);
            }

            // Questão 13 - Ofensas Criminais de Dependentes
            /* Comentado temporariamente até que as propriedades sejam adicionadas ao modelo WorkPermit
            if (workPermit.Page2_HasDependantOffences == true)
            {
                PreencherCampo(campos, _camposMapeados["Page2_DependantsOffences_Yes"], "Yes");

                // Preencher detalhes das ofensas criminais de dependentes
                var ofensasDependentes = workPermit.Page2_DependantOffences.ToList();

                // Primeira ofensa de dependente
                if (ofensasDependentes.Count > 0)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_DependantOffence_0_Nature"], ofensasDependentes[0].Natureza);

                    if (ofensasDependentes[0].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_DependantOffence_0_Date"], 
                            ofensasDependentes[0].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_DependantOffence_0_Location"], ofensasDependentes[0].Local);
                }

                // Segunda ofensa de dependente
                if (ofensasDependentes.Count > 1)
                {
                    PreencherCampo(campos, _camposMapeados["Page2_DependantOffence_1_Nature"], ofensasDependentes[1].Natureza);

                    if (ofensasDependentes[1].Data.HasValue)
                    {
                        PreencherCampo(campos, _camposMapeados["Page2_DependantOffence_1_Date"], 
                            ofensasDependentes[1].Data.Value.ToString("dd/MM/yyyy"));
                    }

                    PreencherCampo(campos, _camposMapeados["Page2_DependantOffence_1_Location"], ofensasDependentes[1].Local);
                }
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page2_DependantsOffences_No"], "Yes");
            }
            */
        }

        private void PreencherPagina_1(WorkPermit workPermit, IDictionary<string, PdfFormField> campos)
        {
            // 1. DADOS PESSOAIS
            PreencherCampo(campos, _camposMapeados["Page1_Surname"], workPermit.Page1_Surname);
            PreencherCampo(campos, _camposMapeados["Page1_MaidenName"], workPermit.Page1_MaidenName);
            PreencherCampo(campos, _camposMapeados["Page1_GivenNames"], workPermit.Page1_GivenNames);
            PreencherCampo(campos, _camposMapeados["Page1_Nationality"], workPermit.Page1_Nationality);

            // 2. DATA DE NASCIMENTO
            if (workPermit.Page1_DateOfBirth.HasValue)
            {
                PreencherCampo(campos, _camposMapeados["Page1_DateOfBirth"],
                    workPermit.Page1_DateOfBirth.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_DateOfBirth"], "N/A");
            }

            // 3. GÊNERO
            if (workPermit.Page1_Gender == "Male")
            {
                PreencherCampo(campos, _camposMapeados["Page1_Gender_Male"], "Yes");
            }
            else if (workPermit.Page1_Gender == "Female")
            {
                PreencherCampo(campos, _camposMapeados["Page1_Gender_Female"], "Yes");
            }

            // 4. PASSAPORTE
            PreencherCampo(campos, _camposMapeados["Page1_PassportNumber"], workPermit.Page1_PassportNumber);

            if (workPermit.Page1_PassportDateIssue.HasValue)
            {
                PreencherCampo(campos, _camposMapeados["Page1_PassportDateIssue"],
                    workPermit.Page1_PassportDateIssue.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_PassportDateIssue"], "N/A");
            }

            PreencherCampo(campos, _camposMapeados["Page1_PassportPlaceIssue"], workPermit.Page1_PassportPlaceIssue);

            if (workPermit.Page1_PassportDateExpiry.HasValue)
            {
                PreencherCampo(campos, _camposMapeados["Page1_PassportDateExpiry"],
                    workPermit.Page1_PassportDateExpiry.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_PassportDateExpiry"], "N/A");
            }

            // 5. OUTROS NOMES
            if (workPermit.Page1_HasOtherNames)
            {
                PreencherCampo(campos, _camposMapeados["Page1_HasOtherNames_Yes"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page1_OtherNames"], workPermit.Page1_OtherNames);
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_HasOtherNames_No"], "No");
            }

            // 6. ENDEREÇO
            PreencherCampo(campos, _camposMapeados["Page1_HouseNumber"], workPermit.Page1_HouseNumber);
            PreencherCampo(campos, _camposMapeados["Page1_StreetName"], workPermit.Page1_StreetName);
            PreencherCampo(campos, _camposMapeados["Page1_District"], workPermit.Page1_District);
            PreencherCampo(campos, _camposMapeados["Page1_POBox"], workPermit.Page1_POBox);
            PreencherCampo(campos, _camposMapeados["Page1_Telephone"], workPermit.Page1_Telephone);

            // 7. EMAIL
            if (workPermit.Page1_HasEmail)
            {
                PreencherCampo(campos, _camposMapeados["Page1_HasEmail_Yes"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page1_Email"], workPermit.Page1_Email);
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_HasEmail_No"], "Yes");
            }

            // 8. ESTADO CIVIL
            if (!string.IsNullOrEmpty(workPermit.Page1_MaritalStatus))
            {
                // Usando switch para determinar qual opção marcar
                switch (workPermit.Page1_MaritalStatus.ToLower())
                {
                    case "single":
                        PreencherCampo(campos, _camposMapeados["Page1_MaritalStatus_Single"], "Yes");
                        break;
                    case "married":
                        PreencherCampo(campos, _camposMapeados["Page1_MaritalStatus_Married"], "Yes");
                        break;
                    case "divorced":
                        PreencherCampo(campos, _camposMapeados["Page1_MaritalStatus_Divorced"], "Yes");
                        break;
                    case "separated":
                        PreencherCampo(campos, _camposMapeados["Page1_MaritalStatus_Separated"], "Yes");
                        break;
                    case "civil partnership":
                        PreencherCampo(campos, _camposMapeados["Page1_MaritalStatus_Civil"], "Yes");
                        break;
                    case "dissolved civil partnership":
                        PreencherCampo(campos, _camposMapeados["Page1_MaritalStatus_Dissolved"], "Yes");
                        break;
                }
            }

            // 9. CÔNJUGE
            PreencherCampo(campos, _camposMapeados["Page1_SpouseInfo"], workPermit.Page1_SpouseInfo);

            // 10. DEPENDENTES
            var dependentes = workPermit.Page1_Dependents.ToList();

            // Primeira linha de dependentes
            if (dependentes.Count > 0)
            {
                PreencherDependente(campos, dependentes[0], 0);
            }

            // Segunda linha de dependentes
            if (dependentes.Count > 1)
            {
                PreencherDependente(campos, dependentes[1], 1);
            }

            // Terceira linha de dependentes
            if (dependentes.Count > 2)
            {
                PreencherDependente(campos, dependentes[2], 2);
            }

            // 11. TRABALHO (questão 8)
            PreencherCampo(campos, _camposMapeados["Page1_PositionAppliedFor"], workPermit.Page1_PositionAppliedFor);
            PreencherCampo(campos, _camposMapeados["Page1_RelevantExperience"], workPermit.Page1_RelevantExperience);

            // Se a experiência relevante for longa, usar o campo de continuação
            if (!string.IsNullOrEmpty(workPermit.Page1_RelevantExperience) &&
                workPermit.Page1_RelevantExperience.Length > 100) // Tamanho arbitrário, ajuste conforme necessário
            {
                // Dividir o texto em duas partes
                string primeiraParte = workPermit.Page1_RelevantExperience.Substring(0, 100);
                string segundaParte = workPermit.Page1_RelevantExperience.Substring(100);

                PreencherCampo(campos, _camposMapeados["Page1_RelevantExperience"], primeiraParte);
                PreencherCampo(campos, _camposMapeados["Page1_RelevantExperience_Continued"], segundaParte);
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_RelevantExperience"], workPermit.Page1_RelevantExperience);
            }

            // Anos de experiência (quando tivermos o ID completo)
            if (workPermit.Page1_YearsExperience.HasValue)
            {
                // Quando tivermos o ID completo:
                PreencherCampo(campos, _camposMapeados["Page1_YearsExperience"], workPermit.Page1_YearsExperience.ToString());
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_YearsExperience"], "N/A");
            }

            // 12. RECURSO PENDENTE (questão 9)
            if (workPermit.Page1_HasPendingAppeal)
            {
                // Quando tivermos os IDs dos checkboxes:
                PreencherCampo(campos, _camposMapeados["Page1_HasPendingAppeal_Yes"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page1_AppealDetails"], workPermit.Page1_AppealDetails);
            }
            else
            {
                PreencherCampo(campos, _camposMapeados["Page1_HasPendingAppeal_No"], "Yes");
                PreencherCampo(campos, _camposMapeados["Page1_AppealDetails"], "N/A");
            }
        }

        #region Mapemamento dos Campos por Pagina

        private void InicializarMapeamento()
        {
            MapeamentoDaPagina_1();
            MapeamentoDaPagina_2();
        }

        private void MapeamentoDaPagina_2()
        {
            string prefixo = $"T[10].Page2a[0]";

            // Campos para ofensas criminais (questão 10)
            _camposMapeados["Page2_CriminalRecord_Yes"] = $"{prefixo}.CheckBox[0]";
            _camposMapeados["Page2_CriminalRecord_No"] = $"{prefixo}.CheckBox[1]";

            // Linha 1 de ofensa criminal
            _camposMapeados["Page2_CriminalOffense_0_Nature"] = $"{prefixo}.TextField[16]";
            _camposMapeados["Page2_CriminalOffense_0_Date"] = $"{prefixo}.Date1";
            _camposMapeados["Page2_CriminalOffense_0_Location"] = $"{prefixo}.TextField[15]";
            _camposMapeados["Page2_CriminalOffense_0_Verdict"] = $"{prefixo}.TextField[17]";

            // Linha 2 de ofensa criminal
            _camposMapeados["Page2_CriminalOffense_1_Nature"] = $"{prefixo}.TextField[10]";
            _camposMapeados["Page2_CriminalOffense_1_Date"] = $"{prefixo}.Date1";
            _camposMapeados["Page2_CriminalOffense_1_Location"] = $"{prefixo}.TextField[9]";
            _camposMapeados["Page2_CriminalOffense_1_Verdict"] = $"{prefixo}.TextField[11]";

            // Deportação (questão 11)
            _camposMapeados["Page2_DeportedCayman_Yes"] = $"{prefixo}.RadioButtonList[0]";
            _camposMapeados["Page2_DeportedCayman_No"] = $"{prefixo}.RadioButtonList[1]";
            _camposMapeados["Page2_DeportedOtherCountry_Yes"] = $"{prefixo}.RadioButtonList[2]";
            _camposMapeados["Page2_DeportedOtherCountry_No"] = $"{prefixo}.RadioButtonList[3]";
            _camposMapeados["Page2_DeportationDetails"] = $"{prefixo}.TextField[8]";

            // Multas administrativas (questão 12)
            _camposMapeados["Page2_AdminFines_Yes"] = $"{prefixo}.RadioButton[0]";
            _camposMapeados["Page2_AdminFines_No"] = $"{prefixo}.RadioButton[1]";

            // Linha 1 de multa administrativa
            _camposMapeados["Page2_AdminFine_0_Nature"] = $"{prefixo}.TextField[23]";
            _camposMapeados["Page2_AdminFine_0_Date"] = $"{prefixo}.Date1";
            _camposMapeados["Page2_AdminFine_0_Location"] = $"{prefixo}.TextField[18]";
            _camposMapeados["Page2_AdminFine_0_Amount"] = $"{prefixo}.TextField[19]";

            // Linha 2 de multa administrativa
            _camposMapeados["Page2_AdminFine_1_Nature"] = $"{prefixo}.TextField[4]";
            _camposMapeados["Page2_AdminFine_1_Date"] = $"{prefixo}.Date1";
            _camposMapeados["Page2_AdminFine_1_Location"] = $"{prefixo}.TextField[5]";
            _camposMapeados["Page2_AdminFine_1_Amount"] = $"{prefixo}.TextField[6]";

            // Sanções profissionais (questão 13)
            _camposMapeados["Page2_ProfessionalSanctions_Yes"] = $"{prefixo}.RadioButton[4]";
            _camposMapeados["Page2_ProfessionalSanctions_No"] = $"{prefixo}.RadioButton[5]";

            // Linha 1 de sanção profissional
            _camposMapeados["Page2_ProfSanction_0_Nature"] = $"{prefixo}.TextField[27]";
            _camposMapeados["Page2_ProfSanction_0_Date"] = $"{prefixo}.Date1";
            _camposMapeados["Page2_ProfSanction_0_Location"] = $"{prefixo}.TextField[25]";
            _camposMapeados["Page2_ProfSanction_0_Reasons"] = $"{prefixo}.TextField[26]";

            // Linha 2 de sanção profissional
            _camposMapeados["Page2_ProfSanction_1_Nature"] = $"{prefixo}.TextField[24]";
            _camposMapeados["Page2_ProfSanction_1_Date"] = $"{prefixo}.Date1";
            _camposMapeados["Page2_ProfSanction_1_Location"] = $"{prefixo}.TextField[6]";
            _camposMapeados["Page2_ProfSanction_1_Reasons"] = $"{prefixo}.TextField[7]";

            // Permissão de trabalho (questão 14)
            _camposMapeados["Page2_DependantOnPermit_Yes"] = $"{prefixo}.RadioButton[6]";
            _camposMapeados["Page2_DependantOnPermit_No"] = $"{prefixo}.RadioButton[7]";
            _camposMapeados["Page2_PermitHolderName"] = $"{prefixo}.TextField[2]";

            // Ausência das Ilhas Cayman (questão 15)
            _camposMapeados["Page2_LeftCayman_Yes"] = $"{prefixo}.RadioButton[8]";
            _camposMapeados["Page2_LeftCayman_No"] = $"{prefixo}.RadioButton[9]";
            _camposMapeados["Page2_AbsenceDetails"] = $"{prefixo}.TextField[0]";
            _camposMapeados["Page2_AbsenceReasons"] = $"{prefixo}.TextField[1]";

            // Ofensas criminais de dependentes (questão 13)
            _camposMapeados["Page2_DependantsOffences_Yes"] = $"{prefixo}.RadioButton[10]";
            _camposMapeados["Page2_DependantsOffences_No"] = $"{prefixo}.RadioButton[11]";

            // Detalhes de ofensas criminais de dependentes - Linha 1
            _camposMapeados["Page2_DependantOffence_0_Nature"] = $"{prefixo}.TextField[21]";
            _camposMapeados["Page2_DependantOffence_0_Date"] = $"{prefixo}.DateTimeField[10]";
            _camposMapeados["Page2_DependantOffence_0_Location"] = $"{prefixo}.TextField[20]";

            // Detalhes de ofensas criminais de dependentes - Linha 2
            _camposMapeados["Page2_DependantOffence_1_Nature"] = $"{prefixo}.TextField[13]";
            _camposMapeados["Page2_DependantOffence_1_Date"] = $"{prefixo}.DateTimeField[13]";
            _camposMapeados["Page2_DependantOffence_1_Location"] = $"{prefixo}.TextField[12]";

            // Histórico de residência (questão 14)
            // Primeira linha
            _camposMapeados["Page2_Residence_0_From"] = $"{prefixo}.DateTimeField7[0]";
            _camposMapeados["Page2_Residence_0_To"] = $"{prefixo}.DateTimeField7[1]";
            _camposMapeados["Page2_Residence_0_Address"] = $"{prefixo}.TextField[28]";

            // Segunda linha
            _camposMapeados["Page2_Residence_1_From"] = $"{prefixo}.DateTimeField7[2]";
            _camposMapeados["Page2_Residence_1_To"] = $"{prefixo}.DateTimeField7[3]";
            _camposMapeados["Page2_Residence_1_Address"] = $"{prefixo}.TextField[29]";

            // Terceira linha
            _camposMapeados["Page2_Residence_2_From"] = $"{prefixo}.DateTimeField7[4]";
            _camposMapeados["Page2_Residence_2_To"] = $"{prefixo}.DateTimeField7[5]";
            _camposMapeados["Page2_Residence_2_Address"] = $"{prefixo}.TextField[30]";
        }

        private void MapeamentoDaPagina_1()
        {
            string prefixo = $"T1[0].Page1[0]";

            // Dados Pessoais
            _camposMapeados["Page1_Surname"] = $"{prefixo}.TextField[11]";
            _camposMapeados["Page1_MaidenName"] = $"{prefixo}.TextField[12]";
            _camposMapeados["Page1_GivenNames"] = $"{prefixo}.TextField[13]";

            _camposMapeados["Page1_Nationality"] = $"{prefixo}.TextField[1]";
            _camposMapeados["Page1_DateOfBirth"] = $"{prefixo}.TextField[0]";

            // Gênero (checkboxes)
            _camposMapeados["Page1_Gender_Male"] = $"{prefixo}.CheckBox[0]";
            _camposMapeados["Page1_Gender_Female"] = $"{prefixo}.CheckBox[1]";

            // Informações de Passaporte
            _camposMapeados["Page1_PassportNumber"] = $"{prefixo}.TextField[2]";
            _camposMapeados["Page1_PassportDateIssue"] = $"{prefixo}.DateTimeField[0]";
            _camposMapeados["Page1_PassportPlaceIssue"] = $"{prefixo}.TextField[8]";
            _camposMapeados["Page1_PassportDateExpiry"] = $"{prefixo}.DateTimeField[1]";

            // Outros nomes

            _camposMapeados["Page1_HasOtherNames_Yes"] = $"{prefixo}.#area[0].CheckBox[3]";
            _camposMapeados["Page1_HasOtherNames_No"] = $"{prefixo}.#area[0].CheckBox[2]";
            _camposMapeados["Page1_OtherNames"] = $"{prefixo}.TextField[10]";

            // Endereço
            _camposMapeados["Page1_HouseNumber"] = $"{prefixo}.TextField[4]";
            _camposMapeados["Page1_District"] = $"{prefixo}.TextField[6]";
            _camposMapeados["Page1_StreetName"] = $"{prefixo}.TextField[5]";
            _camposMapeados["Page1_POBox"] = $"{prefixo}.TextField[3]";
            _camposMapeados["Page1_Telephone"] = $"{prefixo}.TextField[7]";

            _camposMapeados["Page1_HasEmail_Yes"] = $"{prefixo}.CheckBox[5]";
            _camposMapeados["Page1_HasEmail_No"] = $"{prefixo}.CheckBox[4]";
            _camposMapeados["Page1_Email"] = $"{prefixo}.TextField[9]";

            _camposMapeados["Page1_MaritalStatus_Single"] = $"{prefixo}.TextField[17]";
            _camposMapeados["Page1_MaritalStatus_Married"] = $"{prefixo}.TextField[14]";
            _camposMapeados["Page1_MaritalStatus_Divorced"] = $"{prefixo}.TextField[15]";
            _camposMapeados["Page1_MaritalStatus_Separated"] = $"{prefixo}.TextField[16]";
            _camposMapeados["Page1_MaritalStatus_Civil"] = $"{prefixo}.TextField[18]";
            _camposMapeados["Page1_MaritalStatus_Dissolved"] = $"{prefixo}.TextField[19]";

            _camposMapeados["Page1_SpouseInfo"] = $"{prefixo}.TextField[28]";

            // Dependentes - Linha 1
            _camposMapeados["Page1_Dependents_0_Nome"] = $"{prefixo}.TextField[19]";
            _camposMapeados["Page1_Dependents_0_DataNascimento"] = $"{prefixo}.DateTimeField7[0]";
            _camposMapeados["Page1_Dependents_0_Nacionalidade"] = $"{prefixo}.TextField[21]";
            _camposMapeados["Page1_Dependents_0_Relacao"] = $"{prefixo}.TextField[20]";
            _camposMapeados["Page1_Dependents_0_PaisResidencia"] = $"{prefixo}.Country[0]";

            // Dependentes - Linha 2
            _camposMapeados["Page1_Dependents_1_Nome"] = $"{prefixo}.TextField[23]";
            _camposMapeados["Page1_Dependents_1_DataNascimento"] = $"{prefixo}.DateTimeField7[1]";
            _camposMapeados["Page1_Dependents_1_Nacionalidade"] = $"{prefixo}.TextField[22]";
            _camposMapeados["Page1_Dependents_1_Relacao"] = $"{prefixo}.TextField[24]";
            _camposMapeados["Page1_Dependents_1_PaisResidencia"] = $"{prefixo}.Country[1]";

            // Dependentes - Linha 3
            _camposMapeados["Page1_Dependents_2_Nome"] = $"{prefixo}.TextField[26]";
            _camposMapeados["Page1_Dependents_2_DataNascimento"] = $"{prefixo}.DateTimeField7[2]";
            _camposMapeados["Page1_Dependents_2_Nacionalidade"] = $"{prefixo}.TextField[25]";
            _camposMapeados["Page1_Dependents_2_Relacao"] = $"{prefixo}.TextField[27]";
            _camposMapeados["Page1_Dependents_2_PaisResidencia"] = $"{prefixo}.Country[2]";


            // Campos de trabalho - Questão 8
            _camposMapeados["Page1_PositionAppliedFor"] = $"{prefixo}.TextField[14]";
            _camposMapeados["Page1_RelevantExperience"] = $"{prefixo}.TextField[16]";
            _camposMapeados["Page1_RelevantExperience_Continued"] = $"{prefixo}.TextField[15]";
            _camposMapeados["Page1_YearsExperience"] = $"{prefixo}.TextField[17]";

            // Campos de recurso - Questão 9

            _camposMapeados["Page1_HasPendingAppeal_Yes"] = $"{prefixo}.CheckBox[7]";
            _camposMapeados["Page1_HasPendingAppeal_No"] = $"{prefixo}.CheckBox[6]";
            _camposMapeados["Page1_AppealDetails"] = $"{prefixo}.TextField[18]";
        }

        #endregion

        private void PreencherDependente(IDictionary<string, PdfFormField> campos, Dependente dependente, int indice)
        {
            // Nome do dependente
            PreencherCampo(campos, _camposMapeados[$"Page1_Dependents_{indice}_Nome"], dependente.Nome);

            // Data de nascimento
            if (dependente.DataNascimento.HasValue)
            {
                PreencherCampo(campos, _camposMapeados[$"Page1_Dependents_{indice}_DataNascimento"],
                    dependente.DataNascimento.Value.ToString("dd/MM/yyyy"));
            }

            // Nacionalidade
            PreencherCampo(campos, _camposMapeados[$"Page1_Dependents_{indice}_Nacionalidade"], dependente.Nacionalidade);

            // Relação
            PreencherCampo(campos, _camposMapeados[$"Page1_Dependents_{indice}_Relacao"], dependente.Relacao);

            // País de Residência
            PreencherCampo(campos, _camposMapeados[$"Page1_Dependents_{indice}_PaisResidencia"], dependente.PaisResidencia);

            // Se tiver checkbox para "Adicionar ao Work Permit", preencher também
            if (dependente.AdicionarAoVisto)
            {
                // Aqui precisaríamos dos mapeamentos para os checkboxes "Yes" e "No"
                // PreencherCampo(campos, _camposMapeados[$"Page1_Dependents_{indice}_AdicionarAoVisto_Yes"], "Yes");
            }
            else
            {
                // PreencherCampo(campos, _camposMapeados[$"Page1_Dependents_{indice}_AdicionarAoVisto_No"], "Yes");
            }
        }
        private void PreencherCampo(IDictionary<string, PdfFormField> campos, string nomeCampo, string valor)
        {
            // Verificar se o nome do campo ou valor são nulos antes de tentar acessar o dicionário
            if (string.IsNullOrEmpty(nomeCampo) || campos == null)
            {
                return;
            }

            if (campos.ContainsKey(nomeCampo))
            {
                // Se valor for nulo ou vazio, usar "N/A"
                string valorFinal = string.IsNullOrEmpty(valor) ? "N/A" : valor;

                PdfFormField campo = campos[nomeCampo];
                campo.SetValue(valorFinal);
                _logger.LogInformation($"Campo preenchido: {nomeCampo} = {valorFinal}");
            }
            else
            {
                _logger.LogWarning($"Campo não encontrado: {nomeCampo}");
            }
        }
        public async Task<MemoryStream> PreviewPdf1Async(WorkPermit workPermit)
        {
            var resultado = await PreencherPdfAsync(workPermit, true);
            var caminhoArquivo = resultado.ToString();

            // Criar um MemoryStream para armazenar o conteúdo
            var memoryStream = new MemoryStream();

            // Copiar o conteúdo do arquivo para o MemoryStream
            using (var fileStream = File.OpenRead(caminhoArquivo))
            {
                await fileStream.CopyToAsync(memoryStream);
            }

            // Excluir o arquivo temporário
            File.Delete(caminhoArquivo);

            // Posicionar o stream no início
            memoryStream.Position = 0;

            return memoryStream;
        }
        async Task<string> IPdfService.PreencherPdf1Async(WorkPermit workPermit, bool modoPreview, string modeloPdfPath = "")
        {
            var resultado = await PreencherPdfAsync(workPermit, modoPreview, modeloPdfPath);
            return resultado.ToString();
        }
    }
}