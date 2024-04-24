namespace Users.Application.Features.ProductEventSuscriptions.Commands.ProductEventSuscriptionSave ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;

    public class ProductEventSuscriptionSaveHandler(IUnitOfWork _unitOfWork, IMapper _mapper) :
        IRequestHandler<ProductEventSuscriptionSaveCommnand, ProductEventSuscriptionSaveResult>

    {
        public async Task<ProductEventSuscriptionSaveResult> Handle(ProductEventSuscriptionSaveCommnand request, CancellationToken cancellationToken)
        {
            var prodEventSus = new ProductEventSuscriptionSaveResult();
            var eventSus = await _unitOfWork.Repository<ProductEventSuscription>().
                GetAsync(x => x.ProductId == request.ProductId && x.UserId == request.UserId);
            if (eventSus.Count > 0)
            {
                prodEventSus.Id = eventSus[0].Id;
                prodEventSus.Suscribed = false;
                prodEventSus.Message = "Ya antes te habias inscrito a este evento :)";
                return prodEventSus;
            }

            var evenSusCreate = _mapper.Map<ProductEventSuscription>(request);
            await _unitOfWork.Repository<ProductEventSuscription>().
                AddAsync(evenSusCreate);

            prodEventSus.Id = evenSusCreate.Id;
            prodEventSus.Suscribed = true;
            prodEventSus.Message = "Super ya quedaste inscrito :)";
            return prodEventSus;


            throw new NotImplementedException();
        }
    }
